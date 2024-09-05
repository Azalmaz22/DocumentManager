namespace Journal_2
{

     public class Document 
     {
        public string Name;
        public string Sign;
        public string Surname;
        public DateTime? SignDate;
        public int Number;
     }
     enum Actions 
     {
        Create = 1,
        Read = 2,
        Update = 3, 
        Delete = 4,
        Exit = 5,
     }
     internal class Program
     {
        static Document[] Documents = new Document[100];
        static void Main()
        {
            Documents[0] = new Document() { Number = 1, Name = "project document" };
            Documents[1] = new Document() { Number = 2, Name = "house document" };
            Documents[2] = new Document() { Number = 3, Name = "tech document" };

            Console.WriteLine("Hello! It is Document Manager.\n");
            while (true) 
            {
                Console.WriteLine("Choose action:\n");
                Console.WriteLine("1 - Create a new document");
                Console.WriteLine("2 - Read documents");
                Console.WriteLine("3 - Edit documents");
                Console.WriteLine("4 - Delete");
                Console.WriteLine("5 - Exit");

                Console.WriteLine();

                var action_str = Console.ReadLine();
                //int currentMainActionValue;

                //1-Проверка введенных строки: true, false
                //2-Конвертация строки:(var action_str - в число currentMainActionValue)
                // var result = ValidateUserInput(action_str, out currentMainActionValue);
                var result = ValidateUserInput(action_str);
                if (!result)
                {
                    continue;
                }
               var currentMainActionValue = int.Parse(action_str);
                //Переменные в стр.53 и в стр.95 разные


                var currentMainAction = (Actions)currentMainActionValue;
                if (currentMainAction == Actions.Create)
                {
                    CreateNewDocument();

                }
                else if (currentMainAction == Actions.Read)
                {
                    PrintDocuments();

                }
                else if (currentMainAction == Actions.Update)
                {
                    UpdateDocuments();

                }
                else if (currentMainAction == Actions.Delete)
                {
                    DeleteDocuments();

                }
                else if (currentMainAction == Actions.Exit)
                {
                    Console.Clear();

                    Console.WriteLine("Goodbye");
                    
                    break;
                }

                {
                    Console.Clear();
                }            
                
            }
        }

       

        private static bool ValidateUserInput(string? action_str)//, out int currentMainActionValue)
        {
            int currentMainActionValue;
            var convertResult = int.TryParse(action_str, out currentMainActionValue);
            if (!convertResult)
            {
                Console.WriteLine("This is not number. Enter namber! \n\nPress any key to continue...");
                //ожидание нажатия на клавишу
                Console.ReadKey();
                Console.Clear();
                //Переход на следующую итерацию(на начало цикла после захода в 46-49 строки )
                //Не прошли валидацию
                return false;
            }

            if (currentMainActionValue < 1 || currentMainActionValue > 5)
            {
                Console.WriteLine("\nEnter namber between 1 and 5\n\nPress any key to continue...");
                //Ожидание нажатия на клавишу
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            return true;
        }

        private static void DeleteDocuments()
        {
            Console.WriteLine($"Would you like delete all documents ?");
            Console.WriteLine("1 - yes");
            Console.WriteLine("2 - no");
            var answer = Console.ReadLine();
            if ("1" == answer)
            {
                Console.WriteLine("All documents are delete");
               
                 
                      Documents[99] = null;
                      
                              
            }
            else
            {
                Console.WriteLine("Choose document number for delete\n");
                Console.WriteLine("Number\tName\t\tSign\tSurname\tSignDate");
                for (int i = 0; i < Documents.Length; i++)
                {
                    if (Documents[i] != null)
                    {
                       Console.WriteLine(Documents[i].Number + "\t" + Documents[i].Name + "\t\t" + Documents[i].Sign + "\t\t" + Documents[i].Surname + "\t\t" + Documents[i].SignDate);
                    }
                }
                Console.WriteLine();
                //пользователь вводит номер документа. Происходит чтение:
                answer = Console.ReadLine();
                var docNumber = int.Parse(answer);
                //Удаляем документ
                Documents[docNumber] = null;
            }
        }

        private static void UpdateDocuments()
        {
            Console.Clear();
            Console.WriteLine("Choose document number for edit\n");
            Console.WriteLine("Number\t\tName\t\tSign\t\tSurname\t\tSignDate");
            for (int i = 0; i < Documents.Length; i++)
            {
                if (Documents[i] != null)
                {                 
                  Console.WriteLine(Documents[i].Number + "--" + Documents[i].Name + "--" + Documents[i].Sign + "--" + Documents[i].Surname + "---" + Documents[i].SignDate);
                    
                }
            }
            Console.WriteLine();
            var answer = Console.ReadLine();
            var docNumber = int.Parse(answer)-1;
            Console.Clear();
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Sign");
            Console.WriteLine("3 - Surname");
            Console.WriteLine();
            answer = Console.ReadLine();
            var fieldToEdit = int.Parse(answer);
            //ecли мы редактируем имя
            if (fieldToEdit == 1)
            {
                Console.WriteLine("Current name is: " + Documents[docNumber].Name);
                Console.WriteLine("Enter a new name");
                var newName = Console.ReadLine();
                Documents[docNumber].Name = newName;
                Console.WriteLine();
                Console.WriteLine("OK");
                Console.ReadLine();
            }
            // иначе,если мы редактируем подпись
            else if (fieldToEdit == 2)
            {
                while (true)
                {
                    Console.WriteLine("Current sign  is: " + Documents[docNumber].Sign);
                    Console.WriteLine("Enter a new sign ");
                    var newSign = Console.ReadLine();
                    Documents[docNumber].Sign = newSign;
                    Console.WriteLine("Вы ввели правильную подпись?Да или нет");
                    answer = Console.ReadLine();
                    if (answer == "Да")
                    {
                        Console.WriteLine();
                        Console.WriteLine("OK");
                        Console.ReadLine();
                        break;
                    }
                    else if (answer == "нет")
                    {
                        continue;
                    }                                                       
                }
            }

            else if (fieldToEdit == 3) 
            {
                Console.WriteLine("Current surname is: " + Documents[docNumber].Surname);
                Console.WriteLine("Enter a new  surname");
                var newSurname = Console.ReadLine();
                Documents[docNumber].Surname = newSurname;
                Console.WriteLine();
                Console.WriteLine("OK");
                Console.ReadLine();
            }
        }

        private static void PrintDocuments()
        {
            for (int i = 0; i < Documents.Length; i++)
            {
                if (Documents[i] != null)
                {
                    Console.WriteLine(Documents[i].Name);
                }
            }
        }

        private static void CreateNewDocument()
        {
            Console.WriteLine("\nEnter the new document name:");
            var newDocumentName = Console.ReadLine();
            for (int i = 0; i < Documents.Length; i++)
            {
                if (Documents[i] == null)
                {
                    var newDocument = new Document();
                    newDocument.Name = newDocumentName;
                    newDocument.Number = i + 1;
                    Documents[i] = newDocument;
                    break;
                }
            }
        }
     }
}

    

