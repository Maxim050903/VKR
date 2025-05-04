namespace Core.Models
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> questions { get; set; } = new List<string>();
        public List<string> TrueAnswers { get; set; } = new List<string>();

        private Test(Guid id, string Name, List<string> questions, List<string> TrueAnswers)
        {

        }

        private Test(int TestSize)
        {
            var rand = new Random();
            this.questions = new List<string>(TestSize);
            for (int i = 0; i < TestSize; i++)
            {
                var Number = rand.Next();
                
                //questions[i] = rand
            }
        }

    }
}
