using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationClass 
{
    class Person : IdeserializationCallback
    {
        private string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person()
        {

        }

        private static void Serialize(Person sp)
        {
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, sp);
            fs.Close();
        }

        private static Person Deserialize()
        {
            Person dsp = new Person();
            FileStream fs = new FileStream("Person.Dat", FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            dsp = (Person)bf.Deserialize(fs);
            fs.Close();

            return dsp;
        }

        void IDeserializationCallback.OnDeserialization(Object sender)
        {

        }


        static void Main(string[] args)
        {

            Person person = new Person("Kristof",20);
            Serialize(person);
            Deserialize();
        }
    }
}
