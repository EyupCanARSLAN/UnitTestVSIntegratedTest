namespace AppLayer
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var executer = new Controller())
            {
                var personId = executer.CreatePerson("can", "arslan");
                var messageId = executer.SetMessage(personId, "TestMessage");
            }
        }
    }
}
