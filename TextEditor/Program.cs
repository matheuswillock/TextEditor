namespace TextEditor
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
                    "O que você deseja fazer?\n" +
                    "1 - Abrir um arquivo\n" +
                    "2 - Editar um arquivo\n" +
                    "0 - Sair"
                );

            short userOption = short.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: OpenFile(); break;
                case 2: EditFile(); break;
                default: Menu(); break;
            }

        }

        static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            { 
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void EditFile()
        {
            string userText = "";

            Console.Clear();
            Console.WriteLine(
                    "Digite o seu texto abaixo (ESC para sair)\n" +
                    "----------------------------------------------"
                );
            
            do
            {
                userText += Console.ReadLine() + Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SaveFile(userText);
        }   

        static void SaveFile(string text)
        {
            Console.Clear();
            Console.WriteLine(" Qual caminho deseja salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) 
            { 
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

    }
}