using System.Linq;
using System.Collections.Generic;

namespace Forum.App.ViewModels
{
    public abstract class ContentViewModel
    {
        private const int LineLenght = 37;

        protected ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i += LineLenght)
            {
                string row = new string(
                    content.Skip(LineLenght * i)
                    .Take(LineLenght)
                    .ToArray());

                lines.Add(row);
            }

            return lines.ToArray();
        }
    }
}