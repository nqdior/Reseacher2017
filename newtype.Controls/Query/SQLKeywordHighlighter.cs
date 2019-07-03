//****************************************************************************************
// システム名     ： FreeView UIControls [FreeView UI コントロール]
// ファイル名     ： SQLKeywordHighlighter.cs
// Copyright 2009-2010 FreeView. All Rights Reserved.
//****************************************************************************************
using Sgry.Azuki;
using Sgry.Azuki.Highlighter;

namespace newtype.Controls
{
    //========================================================================================
    /// <summary>
    /// SQL のキーワードハイライタです。
    /// </summary>
    /// <![CDATA[
    /// 特記事項 ：
    ///   特になし。
    /// 更新履歴 ：
    ///   2010/05/03 Takahiro Watanabe（新規）。
    /// ]]>
    //========================================================================================
    public class SQLKeywordHighlighter : KeywordHighlighter
    {
        //========================================================================================
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        //========================================================================================
        public SQLKeywordHighlighter()
        {
            // 文字列を設定
            AddEnclosure("'", "'", CharClass.String, '\\');
            AddEnclosure("@\"", "\"", CharClass.String, '\"');
            AddEnclosure("\"", "\"", CharClass.String, '\\');

            // コメントを設定
            AddEnclosure("/*", "*/", CharClass.Comment);
            AddLineHighlight("--", CharClass.Comment);
        }

        //========================================================================================
        /// <summary>
        /// ハイライト処理を行ないます。
        /// </summary>
        /// <param name="doc">ドキュメント。</param>
        //========================================================================================
        public override void Highlight(Document doc)
        {
            int begin = -1;
            int end = -1;

            try
            {
                base.Highlight(doc);
                HighlightBracket(doc, out begin, out end);
            }
            catch
            {
                // 例外無視
            }
        }

        //========================================================================================
        /// <summary>
        /// ハイライト処理を行ないます。
        /// </summary>
        /// <param name="doc">ドキュメント。</param>
        /// <param name="dirtyBegin">開始。</param>
        /// <param name="dirtyEnd">終了。</param>
        //========================================================================================
        public override void Highlight(Document doc, ref int dirtyBegin, ref int dirtyEnd)
        {
            int begin = -1;
            int end = -1;

            try
            {
                base.Highlight(doc, ref dirtyBegin, ref dirtyEnd);
                HighlightBracket(doc, out begin, out end);
            }
            catch
            {
                // 例外無視
            }
        }

        //========================================================================================
        /// <summary>
        /// ブランケットのハイライト処理を行ないます。
        /// </summary>
        /// <param name="doc">ドキュメント。</param>
        /// <param name="begin">開始。</param>
        /// <param name="end">終了。</param>
        /// <returns>ハイライトを行なった場合は true それ以外は false を返します。</returns>
        //========================================================================================
        public bool HighlightBracket(Document doc, out int begin, out int end)
        {
            begin = -1;
            end = -1;

            // "(" のハイライト
            if ((doc.Text.Length > doc.CaretIndex) && (doc.CaretIndex > 0))
            {
                if (doc.Text[doc.CaretIndex - 1] == '(')
                {
                    int match = doc.FindMatchedBracket(doc.CaretIndex - 1);
                    if (match < 0)
                    {
                        return false;
                    }

                    begin = doc.CaretIndex - 1;
                    end = match;

                    doc.SetCharClass(begin, CharClass.Keyword2);
                    doc.SetCharClass(end, CharClass.Keyword2);
                }
            }

            // ")" のハイライト
            if (doc.CaretIndex > 0)
            {
                if (doc.Text[doc.CaretIndex - 1] == ')')
                {
                    int match = doc.FindMatchedBracket(doc.CaretIndex - 1);
                    if (match < 0)
                    {
                        return false;
                    }

                    begin = match;
                    end = doc.CaretIndex - 1;

                    doc.SetCharClass(begin, CharClass.Keyword2);
                    doc.SetCharClass(end, CharClass.Keyword2);
                }
            }

            return true;
        }
    }
}
