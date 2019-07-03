
namespace newtype.Common
{
    public static class StringManager
    {
        /// <summary>
        /// 指定した Unicode 文字が、英字の大文字かどうかを示します。
        /// </summary>
        /// <param name="c">評価する Unicode 文字。</param>
        /// <returns>c が英字の大文字である場合は true。
        /// それ以外の場合は false。</returns>
        public static bool IsUpperLatin(char c)
        {
            //半角英字と全角英字の大文字の時はTrue
            return ('A' <= c && c <= 'Z') || ('Ａ' <= c && c <= 'Ｚ');
        }

        /// <summary>
        /// 指定した Unicode 文字が、英字の小文字かどうかを示します。
        /// </summary>
        /// <param name="c">評価する Unicode 文字。</param>
        /// <returns>c が英字の小文字である場合は true。
        /// それ以外の場合は false。</returns>
        public static bool IsLowerLatin(char c)
        {
            //半角英字と全角英字の小文字の時はTrue
            return ('a' <= c && c <= 'z') || ('ａ' <= c && c <= 'ｚ');
        }
    }
}
