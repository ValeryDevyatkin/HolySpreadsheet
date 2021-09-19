using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace Services.Services
{
    internal class SpreadsheetProcessor : ISpreadsheetProcessor
    {
        private static readonly Dictionary<DelimiterEnum, string> DelimiterMap = new Dictionary<DelimiterEnum, string>
        {
            {DelimiterEnum.Comma, ","},
            {DelimiterEnum.Semicolon, ";"},
            {DelimiterEnum.Tab, "\t"},
            {DelimiterEnum.Whitespace, " "}
        };

        public SpreadsheetProcessor(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public IEnumerable<IEnumerable<string>> ProcessInput(string text, SpreadsheetInputParseParameters parameters)
        {
            var delimiter = parameters.Delimiter == DelimiterEnum.Custom ?
                                parameters.CustomDelimiter :
                                DelimiterMap[parameters.Delimiter];

            var rows = text.Split("\r\n", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var row in rows)
            {
                var editedRow = CutString(row, parameters.RowLeft, parameters.RowRight);

                var words = editedRow.Split(
                    delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                var editedWords = new List<string>();

                foreach (var word in words)
                {
                    var editedWord = CutString(word, parameters.WordLeft, parameters.WordRight);
                    editedWords.Add(editedWord);
                }

                yield return editedWords;
            }
        }

        public string ProcessOutput(IEnumerable<IEnumerable<string>> rows,
                                    SpreadsheetOutputProcessParameters parameters) =>
            throw new NotImplementedException();

        private static string CutString(string str, string left, string right)
        {
            str = str?.Trim();
            left = left?.Trim();
            right = right?.Trim();

            if (!string.IsNullOrEmpty(str) &&
                !string.IsNullOrEmpty(left) &&
                str.IndexOf(left) == 0)
            {
                str = str.Substring(left.Length);
            }

            if (!string.IsNullOrEmpty(str) &&
                !string.IsNullOrEmpty(right))
            {
                var leftRowSideLength = str.Length - right.Length;

                if (str.IndexOf(right) == leftRowSideLength)
                {
                    str = str.Substring(leftRowSideLength);
                }
            }

            return str;
        }
    }
}