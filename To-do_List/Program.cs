namespace To_do_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\JBGA\\Desktop\\Code_Folder\\C# Tests\\ToDoStore.txt";
            ToDoFile file = new ToDoFile(filePath);
            file.MainMenu();
        }
    }
}