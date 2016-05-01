# Csharp-Week15A

# Exercise 1: Input validation

Task

Using Visual Studio, create a new windows application project, and create a basic form, which prompts the user his/her name, e-mail address and phone number.
egy.png

After clicking the save button, evaluate the input if the phone number and e-mail address are valid. 

Since this is not a WinForms-oriented course you can perform this validation simply in the event handler of the save button. 

Hint

For the corresponding Regex expressions use the examples in the presentation. 

Step by step 

1. Name the controls properly, for example 
• txtName
• txtPhone
• txtEmail
• btnSave

2. Add reference to the namespace for using the regular expressions 

using System.Windows.Forms; 
using System.Text.RegularExpressions;

3. Double click the button to create the event handler automatically. Type the following code for the evaluation. 

private void btnSave_Click(object sender, EventArgs e) 
{ 
 if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)*$")) 
   MessageBox.Show("The name is invalid (only alphabetical characters are allowed)"); 
 if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$")) 
   MessageBox.Show("The phone number is not a valid US phone number"); 

 if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-” [email protected]\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) 
   MessageBox.Show("The e-mail address is not valid.");
}

# Exercise 2: Reformat a String 

Task 

In this exercise, you must reformat phone numbers into a standard (###) ###-#### format. You can implement it by extending the previous WinForms application. As an input, you expect a string which matches the following Regex pattern

^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$

You should extract the matching groups from the input and reorganize them for the output format. 

Step by step 

1. Add a method named ReformatPhone that returns a string and accepts a single string as an argument. Reformat the data into the (###) ###-#### format. 

static string ReformatPhone(string s) 
{ 
 Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
 return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]); 
}

Notice that each of the \d{n} expressions is surrounded by parentheses. This places each of the sets of numbers into a separate group that can be easily formatted using String.Format. 

2. Change the btnSave event handler method so that it writes ReformatPhone(s) into the txtPhone field: 

txtPhone.Text = ReformatPhone(txtPhone.Text)

Of course you should execute this line only after the validation! 

# Exercise 3: Convert a Text File to a Different Encoding Type

In this exercise, you convert a text file to UTF-7.

Step by step 

1. Use Visual Studio 2015 to create a blank console application. 

2. Write code to read the C:\boot.ini file, and then write it to a file named bootutf7.txt using the UTF-7 encoding type. For example, the following code (which requires the System.IO namespace) would work: 

StreamReader sr = new StreamReader(@"C:\boot.ini"); 
StreamWriter sw = new StreamWriter("boot-utf7.txt", false, Encoding.UTF7); 

sw.WriteLine(sr.ReadToEnd()); 
sw.Close(); 
sr.Close();

3. Run your application, and open the boot-utf7.txt file in Notepad. If the file was translated correctly, Notepad will display it with some invalid characters because Notepad does not support the UTF-7 encoding type.


# Serialization

# Exercise 1: Make a Class Serializable

Task

In this exercise, you modify a custom class so that developers can easily store it to the disk for later retrieval or transfer it across a network to another .NET Framework application. Open the C# project in the Lesson1-Serialize-People folder, and examine the contents! You need to modify the Person class to make it serializable. What would you do? 

Step by step 

1. Examine the Person class. What changes do you need to make so that the Person class is serializable? You must add the Serializable attribute. 

2. Add the System.Runtime.Serialization namespace to the class. 

3. Add the Serializable attribute to the Person class, and then build the project to ensure it compiles correctly. 

# Exercise 2: Serialize an Object

Task

In this exercise, you write code to store an object to the disk using the most efficient method possible. 

Step by step 

1. Open the Serialize-People project you modified in Exercise 1. 

2. Add the System.IO, System.Runtime.Serialization and System.Runtime.Serialization.Formatters.Binary namespaces to the file containing Main. 

3. Add code to the Serialize method to serialize the sp object to a file in the current directory named Person.dat. Your code could look like the following:
private static void Serialize(Person sp) 
{ 
 // Create file to save the data to 
 FileStream fs = new FileStream("Person.Dat", FileMode.Create);
 // Create a BinaryFormatter object to perform the serialization 
 BinaryFormatter bf = new BinaryFormatter(); 

 // Use the BinaryFormatter object to serialize the data to the file 
 bf.Serialize(fs, sp); 

 // Close the file 
 fs.Close(); 
}

4. Build the project, and resolve any errors. 

5. Open a command prompt to the build directory, and then test the application by running the following command: 

Serialize-People Tony 1923 4 22

6. Examine the serialized data by opening the file your application produced to verify that the name you entered was successfully captured. The date and age information are contained in the serialized data as well; however, they are less easy to interpret in Notepad. 

# Exercise 3: Deserialize an Object

Task

In this exercise, you must read an object from the disk that has been serialized by using BinaryFormatter. 

Step by step 

1. Open the Serialize-People project you modified in Exercises 1 and 2. 

2. Add code to the Deserialize method in the main program to deserialize the dsp object from a file in the default directory named Person.dat. Your code could look like the following: 

private static Person Deserialize() 
{ 
 Person dsp = new Person(); 

 // Open file to read the data from 
 FileStream fs = new FileStream("Person.Dat", FileMode.Open); 

 // Create a BinaryFormatter object to perform the deserialization 
 BinaryFormatter bf = new BinaryFormatter(); 

 // Use the BinaryFormatter object to deserialize the data from the file 
 dsp = (Person)bf.Deserialize(fs); 

 // Close the file 
 fs.Close(); 

 return dsp; 
}

3. Build the project, and resolve any errors. 

4. Open a command prompt to the build directory, and then run the following command with no command-line parameters: 

Serialize-People

Note that the Serialize-People command displays the name, date of birth, and age of the previously serialized Person object. 

Exercise 4: Optimize a Class for Deserialization 

Task 

In this exercise, you modify a class to improve the efficiency of serialization. 

Step by step

1. Open the SerializePeople project you modified in Exercises 1, 2, and 3. 

2. Modify the Person class to prevent the age member from being serialized. To do this, add the NonSerialized attribute to the member, as the following code demonstrates: 

[NonSerialized] public int age; 

3. Build and run the project with no command-line parameters. Note that the Serialize-People command displays the name and date of birth of the previously serialized Person object. However, the age is displayed as zero. 

4. Modify the Person class to implement the IDeserializationCallback interface, as the following code snippet demonstrates: 

namespace Serialize_People 
{ 
 [Serializable] 
 class Person : IdeserializationCallback
 {
 }
}

5. Add the IDeserializationCallback.OnDeserialization method to the Person class. Your code could look like the following: 

void IDeserializationCallback.OnDeserialization(Object sender) 
{ 

}

6. Build and run the project with no command-line parameters. Note that the Serialize-People command displays the name, date of birth, and age of the previously serialized Person object. The age displays properly this time because it is calculated immediately after deserialization. 

// After deserialization, calculate the age 
CalculateAge();

# Exercise 5: Update a Class to Use Custom Serialization 

Task 

In this exercise, you will update a class to improve the efficiency of serialization while maintaining complete control over how data is stored and retrieved. You can continue from the C# project in the Lesson3-Serialize-People folder. 

Step by step 

1. Add the System.Runtime.Serialization namespace to the Person class. 

2. Add the Serializable attribute to the Person class, and then build the project to ensure it compiles correctly. 

3. Modify the Person class so that it implements ISerializable. 

4. Add the GetObjectData method, which accepts a SerializationInfo object and a StreamingContext object, and adds items to be serialized to the SerializationInfo object. Add the name and dateOfBirth variables to the SerializationInfo object, but do not add the age variable. Your code could look like the following:

public virtual void GetObjectData(SerializationInfo info, 
StreamingContext context) 
{ 

}

5. Add the serialization constructor, which accepts a SerializationInfo object and a StreamingContext object, and then initializes member variables using the contents of the SerializationInfo object. Use the same element names you used in the previous step. After you have deserialized all variables, call the CalculateAge method to initialize the age variables. Your code could look like the following: 

public Person(SerializationInfo info, StreamingContext context) 
{ 
 info.AddValue("Name", name); 
 info.AddValue("DOB", dateOfBirth);
 name = info.GetString("Name"); 
 dateOfBirth = info.GetDateTime("DOB"); 
 CalculateAge(); 
}

6. Build the project, and resolve any errors. 

7. Open a command prompt to the build directory, and then run the following command: 

Serialize-People Tony 1923 4 22

8. Now run the command with no parameters to verify that deserialization works properly.
static void Main(string[] args) 
{ 
... 

 //search recursively for the mathing files 
 RecursiveSearch(FoundFiles, fileName, rootDir); 

 //list the found files 
 Console.WriteLine("Found {0} files.", FoundFiles.Count); 

 foreach (FileInfo fil in FoundFiles) 
 { 
 Console.WriteLine("{0}", fil.FullName); 
 }

 Console.ReadKey(); 

 
 
 
#  Threading

# Exercise 1: Create Multiple Threads

In this exercise, you create a simple console application and start two threads simultaneously. 

1. Create a new console application, and call it SimpleThreadingDemo. 

2. Create a new static method called Counting. 

3. In the new class, add an include statement (or the Imports statement for Visual Basic) to the System.Threading namespace. 

4. In the new method, create a for loop that counts from 1 to 10. 

5. Within the new for loop, write out the current count and the ManagedThreadId for the current thread. 

6. After writing out to the console, sleep the current thread for 10 milliseconds. 

7. Go back to the Main method, and create a new StartThread delegate that points to the Counting method. 

8. Now create two threads, each pointing to the Counting method. 

9. Start both threads. 

10. Join both threads to ensure that the application doesn’t complete until the threads are done. Your code should look something like this: 

// Csharp 

using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Threading; 

class Program 
{ 
 static void Main(string[] args) 
 { 
  ThreadStart starter = new ThreadStart(Counting); 
  Thread first = new Thread(starter); 
  Thread second = new Thread(starter); 

  first.Start(); 
  second.Start();

  first.Join(); 
  second.Join(); 

  Console.Read(); 
 } 

 static void Counting() 
 { 
  for (int i = 1; i <= 10; i++) 
  { 
   Console.WriteLine("Count: {0} - Thread: {1}",i, Thread.CurrentThread.ManagedThreadId); 
   Thread.Sleep(10); 
  } 
 } 
}

11. Build the project, and resolve any errors. Verify that the console application successfully shows the threads running concurrently. You can determine this by checking whether each thread’s counts are intermingled with those of other threads. The exact nature of the intermingling is dependent on the type of hardware you have. A single processor machine will be very ordered, but a multiprocessor (or multicore) machine will be somewhat random. 

# Exercise 2: Use a Mutex to Create a Single-Instance Application 

In this lab, you create a simple console application in which you will use a Mutex to ensure there is only one instance of the application running at any point. If you encounter a problem completing an exercise, the completed projects are available on the companion CD in the Code folder. 

1. Create a new console application called SingleInstance. 

2. In the main code file, include (or import for Visual Basic) System.Threading. 

3. In the main method of the console application, create a local Mutex variable and assign it a null (or Nothing in Visual Basic). 

4. Create a constant string to hold the name of the shared Mutex. Make the value “RUNMEONCE”. 

5. Create a try/catch block. 

6. Inside the try section of the try/catch block, call the Mutex.OpenExisting method, using the constant string defined in step 4 as the name of the Mutex. Then assign the result to the Mutex variable created in step 2. 

7. For the catch section of the try/catch block, catch a WaitHandleCannotBeOpenedException to determine that the named Mutex doesn’t exist. 

8. Next, test the Mutex variable created in step 2 for null (or Nothing in Visual Basic) to see whether the Mutex could be found. 

9. If the Mutex was not found, create the Mutex with the constant string from step 

10. If the Mutex was found, close the Mutex variable and exit the application. Your final code might look something like this: 

// Csharp 

using System.Threading; 

class Program 
{ 
 static void Main(string[] args) 
 { 
  Mutex oneMutex = null; 
  const string MutexName = "RUNMEONLYONCE"; 

  try // Try and open the Mutex 
  { 
   oneMutex = Mutex.OpenExisting(MutexName); 
  } 
  catch (WaitHandleCannotBeOpenedException) 
  { 
   // Cannot open the mutex because it doesn't exist 
  } 

  // Create it if it doesn't exist 
  if (oneMutex == null) 
  { 
   oneMutex = new Mutex(true, MutexName); 
  } 
  else
  { 
   // Close the mutex and exit the application 
   // because we can only have one instance 
   oneMutex.Close(); 
   return; 
  }

  Console.WriteLine("Our Application"); 
  Console.Read(); 
 } 
}

11. Build the project, and resolve any errors. Verify that only one instance of the 

application can be run at once. 

# Exercise 3: Use the ThreadPool to Queue Work Items 

In this lab, you will create an application that uses the thread pool to queue up methods to call on separate threads. If you encounter a problem completing an exercise, the completed projects are available on the companion CD in the Code folder. 

1. Create a blank console application with the name ThreadPoolDemo. 

2. Include (or import for Visual Basic) the System.Threading namespace. 

3. Create a new method to simply display some text. Call it ShowMyText. Accept one parameter of type object, and call it state. 

4. Create a new string variable inside the ShowMyText method, and cast the state parameter to a string while storing it in the new text variable. 

5. Inside the ShowMyText method, write out the ManagedThreadId of the current thread and write the new string out to the console.

6. In the Main method of the console application, create a new instance of the WaitCallback delegate that refers to the ShowMyText method. 

7. Use the ThreadPool to queue up several calls to the WaitCallback delegate, specifying different strings as the object state. Your code might look something like this: 

// Csharp

using System.Threading; 

class Program 
{ 
 static void Main(string[] args) 
 { 
  WaitCallback callback = new WaitCallback(ShowMyText);

  ThreadPool.QueueUserWorkItem(callback, "Hello"); 
  ThreadPool.QueueUserWorkItem(callback, "Hi"); 
  ThreadPool.QueueUserWorkItem(callback, "Heya"); 
  ThreadPool.QueueUserWorkItem(callback, "Goodbye"); 

  Console.Read();
 } 

 static void ShowMyText(object state) 
 { 
  string myText = (string)state; 
  Console.WriteLine("Thread: {0} - {1}", 
  Thread.CurrentThread.ManagedThreadId, myText);
 } 
}

8. Build the project, and resolve any errors. Verify that the console application successfully shows each of the calls to the ShowMyText methods out to the console. 

Note that some of the work items are executed on different threads.
