using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace VS2012.ConsoleApp.AutofacUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelectTwoPamameterConstructorWithTypedParameter()
        {
            var builder = new ContainerBuilder();
            IMyObjectType tt;
            builder.RegisterType<MyObjectType>().As<IMyObjectType>();
            using (var result = builder.Build())
            {
                tt = result.Resolve<IMyObjectType>(new TypedParameter(typeof(int), 2),
                                                     new TypedParameter(typeof(string), "22"));

            }
            Assert.AreEqual(tt.Id, 2);
            Assert.AreEqual(tt.Name, "22");
        }


    }
    public class CarTransportModule : Module
    {
        public bool ObeySpeedLimit { get; set; }

        protected override void Load(ContainerBuilder builder)
        {




        }
    }
    internal interface IMyObjectType
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    class MyObjectType : IMyObjectType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MyObjectType()
        {
        }

        public MyObjectType(string name)
        {
        }

        public MyObjectType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }


    }
}
