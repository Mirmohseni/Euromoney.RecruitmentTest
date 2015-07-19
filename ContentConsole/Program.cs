using ContentConsole.DAL;
using ContentConsole.Core;
using System;

namespace ContentConsole
{
    public static class Program
    {
        enum Roles { User, Administrator, Reader, ContentCurator };

        public static void Main(string[] args)
        {
            IRepository repository = new FileRepository();

            IContentAnalyser contentAnalyser = new ContentAnalyser(repository.GetContent(), repository.GetNegativeWords());
            Roles role = Roles.User;

            if (args.Length > 0)
            {
                if(args[0].StartsWith("-role:"))
                {
                    var roleString = args[0].Substring(6);
                    Enum.TryParse<Roles>(roleString, true, out role);
                }
            }

            var contentProcessor = new ContentProcessor(); 
            switch (role)
            {
                case Roles.User:
                    contentProcessor.WriteOrginalContent();
                    break;
                case Roles.Administrator:
                    contentProcessor.WriteOrginalContent();
                    break;
                case Roles.Reader:
                    contentProcessor.WriteFilteredContent();
                    break;
                case Roles.ContentCurator:
                    contentProcessor.WriteOrginalContent();
                    break;
                default:
                    break;
            }
        }
    }
    
    public class ContentProcessor{
        public void WriteOrginalContent()
        {
            IRepository repository = new FileRepository();
            IContentAnalyser contentAnalyser = new ContentAnalyser(repository.GetContent(), repository.GetNegativeWords());

            var negativeWords = contentAnalyser.CountNegativeWords();
            var allNegativeWords = contentAnalyser.CountAllNegativeWords();
            var content = repository.GetContent();

            Console.WriteLine("Scanned the text:");
            Console.WriteLine(content);
            Console.WriteLine("Total Number of distinct negative words: " + negativeWords);
            Console.WriteLine("Total Number of all negative words: " + allNegativeWords);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
        public void WriteFilteredContent()
        {
            IRepository repository = new FileRepository();
            IContentAnalyser contentAnalyser = new ContentAnalyser(repository.GetContent(), repository.GetNegativeWords());

            var filteredContent = contentAnalyser.FilterContent();

            Console.WriteLine(filteredContent);

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
    }
}
