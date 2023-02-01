namespace TextEditor2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine(
                    "O que você deseja fazer?\n\n" +
                    "1 - Abrir um arquivo.\n" +
                    "2 - Editar um arquivo.\n" +
                    "0 - sair.\n"
                );

            var option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "0": System.Environment.Exit(0);
                    break;
                case "1": OpenFile();
                    break;
                case "2": EditFile();
                    break;
                default: Menu();
                    break;
            }
        }

        static void OpenFile() { 
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");

            string path = Console.ReadLine() ?? "";

            if (path == "" || path == " ") OpenFile();

            using (var file = new StreamReader(path))
            {
                Console.Clear();
                string text = file.ReadToEnd();
                Console.WriteLine($"{path}\n\n{text}");
            }

            Console.WriteLine("Tecle enter para sair.");
            Console.ReadLine();

            Menu();

        }

        static void EditFile() {
            string userText = "";

            Console.Clear();
            Console.WriteLine("Escreva o seu texto abaixo:\n\n -------------------------------- \n");

            do {
                userText += Console.ReadLine() + Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine();

            SaveFile(userText);
        }

        static void SaveFile(string text) 
        {
            Console.Clear();
            Console.WriteLine("QQual caminho deseja salvar o arquivo?");

            var path =  Console.ReadLine() ?? "";

            if (path == "" || path == " ") SaveFile(text);

            using (var file = new StreamWriter(path))
            { 
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");

            Console.WriteLine("\n\nTecle enter para sair.");
            Console.ReadLine();

            Menu();
        }
    }
}
