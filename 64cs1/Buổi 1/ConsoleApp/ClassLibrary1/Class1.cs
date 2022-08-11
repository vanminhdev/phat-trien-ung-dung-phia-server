namespace ClassLibrary1
{
    /// <summary>
    /// Đây là class 1.
    /// </summary>
    public class Class1
    {
        public int Id { get; set; }
        private string _name;

        /// <summary>
        /// Đây là hàm hello.
        /// </summary>
        /// <param name="id"></param>
        public void Hello(int id)
        {
            Id = id;
        }
    }
}