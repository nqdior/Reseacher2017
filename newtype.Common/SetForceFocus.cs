using System;
using System.Runtime.InteropServices;

namespace newtype.Common
{
    /* http://devlights.hatenablog.com/entry/20071211/p1 */
    public class SetForceFocus
    {
        //////////////////////////////////////////////////////////////////
        //
        // 以下Win32Apiの宣言.
        //
        //
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        extern static bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// 強制的にウィンドウをアクティブにする際に利用される独自ウィンドウメッセージ (WM_USERの値に1加算)
        /// </summary>
        const int MY_FORCE_FOREGROUND_MESSAGE = 0x400 + 1;
        /// <summary>
        /// 指定されたハンドルを持つウィンドウを強制的にアクティブにします。
        /// </summary>
        /// <param name="targetHandle">対象となるウィンドウハンドルオブジェクト</param>
        public static void SetForceForegroundWindow(IntPtr targetHandle)
        {
            uint nullProcessId = 0;

            // ターゲットとなるハンドルのスレッドIDを取得.
            uint targetThreadId = GetWindowThreadProcessId(targetHandle, out nullProcessId);
            // 現在アクティブとなっているウィンドウのスレッドIDを取得.
            uint currentActiveThreadId = GetWindowThreadProcessId(GetForegroundWindow(), out nullProcessId);

            ////////////////////////////////////////////////
            //
            // アクティブ処理
            //
            //
            SetForegroundWindow(targetHandle);
            if (targetThreadId == currentActiveThreadId)
            {
                //
                // 現在アクティブなのが自分の場合は前面に持ってくる。
                //
                BringWindowToTop(targetHandle);
            }
            else
            {
                //
                // 別のプロセスがアクティブな場合は、そのプロセスにアタッチし、入力を奪う.
                //
                AttachThreadInput(targetThreadId, currentActiveThreadId, true);
                try
                {
                    //
                    // 自分を前面に持ってくる。
                    //
                    BringWindowToTop(targetHandle);
                }
                finally
                {
                    //
                    // アタッチを解除.
                    //
                    AttachThreadInput(targetThreadId, currentActiveThreadId, false);
                }
            }
        }
    }
}
