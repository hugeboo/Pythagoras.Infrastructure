using DevExpress.XtraEditors;
using Pythagoras.Infrastructure.CubeClients.ClockSignal;
using Pythagoras.Infrastructure.Realtime;
using Pythagoras.Infrastructure.WebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace Pythagoras.Infrastructure.WinForms.CubeForms.ClockSignal
{
    public partial class ClockSignalForm : DevExpress.XtraEditors.XtraForm
    {
        private ClockSignalSettings? _settings;
        private ClockSignalState? _state;

        private readonly IClockSignalClient _client = default!;

        public ClockSignalForm()
        {
            InitializeComponent();
        }

        public ClockSignalForm(string serverUrl)
        {
            InitializeComponent();

            labelClockTime.Text = null;
            labelTick.ImageOptions.SvgImage = null;

            _client = new ClockSignalClient(serverUrl ?? throw new ArgumentNullException(nameof(serverUrl)));
            _client.VirtualTimeChanged += client_VirtualTimeChanged;
            _client.ClockTimeChanged += client_ClockTimeChanged;
            _client.ClockSignalStateChanged += client_ClockSignalStateChanged;
        }

        private ClockSignalSettings GetSettingsFromControl()
        {
            return new ClockSignalSettings
            {
                Mode = checkEditBackMode.Checked ? ClockSignalSettings.ClockSignalMode.Backtesting : ClockSignalSettings.ClockSignalMode.Realtime,
                StartDate = dateEditStartDate.DateTime.Date,
                EndDate = dateEditEndDate.DateTime.Date,
                StartTime = timeEditStartTime.Time.TimeOfDay,
                EndTime = timeEditEndTime.Time.TimeOfDay,
                TimeFactor = radioGroupFactor.EditValue != null ? (double)radioGroupFactor.EditValue : 1.0
            };
        }

        private void SetSettings(ClockSignalSettings settings)
        {
            _settings = settings;
            UpdateControls();
        }

        private void SetState(ClockSignalState state)
        {
            _state = state;
            UpdateControls();
        }

        private void UpdateControls()
        {
            if (_settings == null) return;

            checkEditRealtimeMode.Checked = _settings.Mode == ClockSignalSettings.ClockSignalMode.Realtime;
            checkEditBackMode.Checked = !checkEditRealtimeMode.Checked;
            radioGroupFactor.EditValue = _settings.TimeFactor;
            dateEditStartDate.EditValue = _settings.StartDate;
            dateEditEndDate.EditValue = _settings.EndDate;
            timeEditStartTime.EditValue = _settings.StartTime;
            timeEditEndTime.EditValue = _settings.EndTime;
        }

        public void DisableControls()
        {
            labelTick.Visible = false;
            labelClockTime.Visible = false;
            foreach (Control control in this.Controls)
            {
                if (ReferenceEquals(control, labelClockTime) || ReferenceEquals(control, labelTick))
                    continue;

                control.Enabled = false;
            }
        }

        public void EnableControls()
        {
            if (_state == null)
            {
                DisableControls();
            }
            else
            {
                if (_state!.IsRunning)
                {
                    simpleButtonStart.Enabled = false;
                    simpleButtonStop.Enabled = true;
                    foreach (Control control in this.Controls)
                    {
                        if (ReferenceEquals(control, labelClockTime) || ReferenceEquals(control, labelTick))
                            continue;

                        if (!(control is SimpleButton)) control.Enabled = false;
                    }
                }
                else
                {
                    labelTick.Visible = true;
                    labelClockTime.Visible = true;

                    simpleButtonStart.Enabled = true;
                    simpleButtonStop.Enabled = false;
                    checkEditRealtimeMode.Enabled = true;
                    checkEditBackMode.Enabled = true;
                    radioGroupFactor.Enabled = checkEditBackMode.Checked;
                    dateEditStartDate.Enabled = checkEditBackMode.Checked;
                    dateEditEndDate.Enabled = checkEditBackMode.Checked;
                    timeEditStartTime.Enabled = checkEditBackMode.Checked;
                    timeEditEndTime.Enabled = checkEditBackMode.Checked;
                    foreach (Control control in this.Controls)
                    {
                        if (ReferenceEquals(control, labelClockTime) || ReferenceEquals(control, labelTick))
                            continue;
                        
                        if (control is LabelControl) control.Enabled = checkEditBackMode.Checked;
                    }
                }
            }
        }

        private ClockSignalSettings? GetSettingsFromServer()
        {
            var result = _client?.GetSettingsAsync().GetAwaiter().GetResult();
            if (result == null) throw new InvalidOperationException("Can`t get ClockSignalSettings from server.");
            if (!result.Successfully)
            {
                var m = "An error has occured:\n\n";
                if (result.Errors != null) m += result.Errors.ToErrorText();
                throw new InvalidOperationException(m);
            }
            return result.Result;
        }

        private void GetSettingsFromServerAndApply()
        {
            UtilsUI.DoBackground<ClockSignalSettings?>(
                 () => GetSettingsFromServer(),
                 (result) => { if (result != null) SetSettings(result); },
                 (ex) => UtilsUI.ShowMessageBox(ex));
        }

        private ClockSignalState? GetStateFromServer()
        {
            var result = _client?.GetStateAsync().GetAwaiter().GetResult();
            if (result == null) throw new InvalidOperationException("Can`t get ClockSignalState from server.");
            if (!result.Successfully)
            {
                var m = "An error has occured:\n\n";
                m += result.Errors.ToErrorText();
                throw new InvalidOperationException(m);
            }
            return result.Result;
        }

        private void GetStateFromServerAndApply()
        {
            UtilsUI.DoBackground<ClockSignalState?>(
                 () => GetStateFromServer(),
                 (result) => { if (result != null) SetState(result); },
                 (ex) => UtilsUI.ShowMessageBox(ex));
        }

        private void simpleButtonStart_Click(object sender, EventArgs e)
        {
            _settings = GetSettingsFromControl();

            UtilsUI.DoBackground<ClockSignalState?>(
                 () =>
                 {
                     _client?.SetSettingsAsync(_settings).GetAwaiter().GetResult();
                     _client?.StartAsync().GetAwaiter().GetResult();
                     return GetStateFromServer();
                 },
                 (state) => { if (state != null) SetState(state); },
                 (ex) => UtilsUI.ShowMessageBox(ex));
        }

        private void simpleButtonStop_Click(object sender, EventArgs e)
        {
            UtilsUI.DoBackground<ClockSignalState?>(
                () =>
                {
                    _client?.StopAsync().GetAwaiter().GetResult();
                    return GetStateFromServer();
                },
                (state) => { if (state != null) SetState(state); },
                (ex) => UtilsUI.ShowMessageBox(ex));
        }

        private void ClockSignalForm_Load(object sender, EventArgs e)
        {
            UtilsUI.DoBackground<(ClockSignalSettings?, ClockSignalState?)>(
                () =>
                {
                    _client.InitializeWebApiClient();
                    _client.InitializeAndStartHubConnectionAsync().GetAwaiter().GetResult();

                    var settings = GetSettingsFromServer();
                    var state = GetStateFromServer();
                    return (settings, state);
                },
                (res) =>
                {
                    if (res.Item1 != null) SetSettings(res.Item1);
                    if (res.Item2 != null) SetState(res.Item2);
                },
                (ex) => UtilsUI.ShowMessageBox(ex));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            EnableControls();
        }

        private void checkEditRealtimeMode_CheckedChanged(object sender, EventArgs e)
        {
            checkEditBackMode.Checked = !checkEditRealtimeMode.Checked;
        }

        private void checkEditBackMode_CheckedChanged(object sender, EventArgs e)
        {
            checkEditRealtimeMode.Checked = !checkEditBackMode.Checked;
        }

        private void client_ClockSignalStateChanged(object? sender, StringEventArgs e)
        {
            this.BeginInvokeSafe(() =>
            {
                if (e.Text == "HubConnectionClosed" || e.Text == "HubReconnecting")
                {
                    labelTick.ImageOptions.SvgImage = Properties.Resources.circle_filled_yellow;
                }
                else if (e.Text == "HubReconnected")
                {
                    labelTick.ImageOptions.SvgImage = null;
                }
                else
                {
                    GetStateFromServerAndApply();
                }
            });
        }

        private void client_ClockTimeChanged(object? sender, TimeEventArgs e)
        {
            this.BeginInvokeSafe(() =>
            {
                labelClockTime.Visible = true;
                labelClockTime.Text = e.Time.ToString("HH:mm:ss.fff");
            });
        }

        private void client_VirtualTimeChanged(object? sender, TimeEventArgs e)
        {
            this.BeginInvokeSafe(() =>
            {
                labelTick.Visible = true;
                labelTick.ImageOptions.SvgImage = Properties.Resources.circle_filled_green;
                UtilsUI.ExecuteWithDelay(500, () => labelTick.ImageOptions.SvgImage = null);
            });
        }
    }
}