using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pythagoras.Infrastructure.WinForms
{
    public static class UtilsUI
    {
        const int MF_BYCOMMAND = 0;
        const int MF_DISABLED = 2;
        const int SC_CLOSE = 0xF060;
        
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        public static void DisableCloseButton(this Form form)
        {
            var sm = GetSystemMenu(form.Handle, false);
            EnableMenuItem(sm, SC_CLOSE, MF_BYCOMMAND | MF_DISABLED);
        }

        public static void BeginInvokeSafe(this Control control, Action action)
        {
            if (!control.IsHandleCreated) return;
            _ = control.BeginInvoke(action);
        }

        public static void ExecuteWithDelay(int delayMs, Action action)
        {
            DoBackground(() => Task.Delay(delayMs).Wait(), () => action());
        }

        public static void DoBackground(Action backgroundAction, Action? onSuccessfully = null, Action<Exception?>? onError = null)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                backgroundAction();
            })
            .ContinueWith((t) =>
            {
                if (t.IsCompletedSuccessfully && onSuccessfully != null) onSuccessfully();
                else if (onError != null) onError(t.Exception);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static void DoBackground<T>(Func<T> backgroundFunc, Action<T>? onSuccessfully = null, Action<Exception?>? onError = null)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                return backgroundFunc();
            })
            .ContinueWith((t) =>
            {
                if (t.IsCompletedSuccessfully && onSuccessfully != null) onSuccessfully(t.Result);
                else if (onError != null) onError(t.Exception);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static string EllipsisPath(this string path, Font font, Size size)
        {
            if (string.IsNullOrEmpty(path)) return path;

            string result = new string(path);
            // TODO: Use Utils.EllipsisString
#pragma warning disable CS0618 // Тип или член устарел
            TextRenderer.MeasureText(result, font, size,
                TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);
#pragma warning restore CS0618 // Тип или член устарел
            var index0 = result.IndexOf('\0');
            if (index0 >= 0) result = result.Substring(0, index0);
            return result;
        }

        public static string EllipsisString(this string rawString, int maxLength = 30, char delimiter = '\\')
        {
            maxLength -= 3; //account for delimiter spacing

            if (rawString.Length <= maxLength)
            {
                return rawString;
            }

            string final = rawString;
            List<string> parts;

            int loops = 0;
            while (loops++ < 100)
            {
                parts = rawString.Split(delimiter).ToList();
                parts.RemoveRange(parts.Count - 1 - loops, loops);
                if (parts.Count == 1)
                {
                    return parts.Last();
                }

                parts.Insert(parts.Count - 1, "...");
                final = string.Join(delimiter.ToString(), parts);
                if (final.Length < maxLength)
                {
                    return final;
                }
            }

            return rawString.Split(delimiter).ToList().Last();
        }

        public static void ShowMessageBox(Exception? ex)
        {
            MessageBox.Show(ex?.Message ?? "Unknown exception", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string ToErrorText(this Dictionary<string, string[]>? errors)
        {
            if (errors == null) return "Unknown error";

            var sb = new StringBuilder();
            foreach (var error in errors)
            {
                var v = error.Value != null ? string.Join(", ", error.Value) : string.Empty;
                sb.Append(error.Key).Append(": ").Append(v).Append("\n");
            }
            return sb.ToString();
        }
    }
}
