namespace AbstractClass
{
    public class InputDtoBase
    {
        public int Id { get; set; }
    }

    public class InputDto : InputDtoBase
    {
        public string Name { get; set; }
    }

    public class InputDto2 : InputDtoBase
    {
        public string Name2 { get; set; }
    }

    public interface IMyInterface
    {
        void DoSomethingOther<T>(T input) where T : InputDtoBase;
    }

    public abstract class MyClass<TInputDto> where TInputDto : InputDtoBase
    {
        public abstract void DoSomething(TInputDto input);
    }

    public class MyDerivedClass1 : MyClass<InputDto>, IMyInterface
    {
        public override void DoSomething(InputDto input)
        {
        }

        public void DoSomethingOther<T>(T input) where T : InputDtoBase
        {
            throw new NotImplementedException();
        }
    }

    public abstract class MyClass2
    {
        public abstract void DoSomething<T>(T input) where T : InputDtoBase;
    }

    public class MyDerivedClass2 : MyClass2
    {
        public override void DoSomething<T>(T input)
        {
            input.Id = 1;
            var input2 = input as InputDto2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new MyDerivedClass1();
            test.DoSomething(new InputDto());
        }
    }
}