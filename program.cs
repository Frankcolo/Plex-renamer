using System;
using System.IO;

namespace PlexRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            string savedname = "";
            char continueloop = 'Y';
            int season = 0;
            
            while (char.ToUpper(continueloop) == 'Y')
            {
                char folderfound = 'N';
                nfile file1 = new nfile();
                int epcount = 1;
                int foldernum = 0;
                string extention;
                string folderpath = "";
                while (char.ToUpper(folderfound) == 'N')
                {
                    foldernum = 0;
                    Console.WriteLine("Enter folder path:\n");
                    folderpath = Console.ReadLine();
                    if (Directory.Exists(folderpath) != false)
                    {
                        Console.WriteLine("directory found with following files:");
                        foreach (string file in Directory.EnumerateFiles(folderpath))
                        {
                            Console.WriteLine(file);
                            foldernum++;
                        }
                        Console.WriteLine("Is this correct(Y/N)?");
                        folderfound = Convert.ToChar(Console.ReadLine());
                        while (char.ToUpper(folderfound) != 'Y' && char.ToUpper(folderfound) != 'N')
                        {
                            Console.WriteLine("Invalid entry please try again:");
                            folderfound = Convert.ToChar(Console.ReadLine());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Folder not found. Please reenter: ");
                    }
                }

                Console.WriteLine("Enter Name of show or hit enter to reuse: {0}",savedname);
                string name = Convert.ToString(Console.ReadLine());
                if (name == "" && savedname != "")
                {
                    name = savedname;
                }
                else if (name==""&&savedname=="")
                {
                    while(name=="")
                    {
                        Console.WriteLine("No name entered or stored. Please reenter");
                        name = Convert.ToString(Console.ReadLine());
                    }
                }
                savedname = name;
                Console.WriteLine("Enter Season of show:");
                try
                {
                    season = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("invalid format please re-enter:");
                    season = Convert.ToInt32(Console.ReadLine());
                }





                foreach (string file in Directory.EnumerateFiles(folderpath))
                {
                    if (epcount <= foldernum)
                    {
                        extention = Path.GetExtension(file);
                        if (epcount < 10 && season < 10)
                        {
                            file1.filename = Convert.ToString(folderpath + "\\" + name + " S0" + season + "E0" + epcount + extention);
                        }
                        else if (epcount < 10 && season >= 10)
                        {
                            file1.filename = Convert.ToString(folderpath + "\\" + name + " S" + season + "E0" + epcount + extention);
                        }
                        else if (epcount >= 10 && season >= 10)
                        {
                            file1.filename = Convert.ToString(folderpath + "\\" + name + " S" + season + "E" + epcount + extention);
                        }
                        else if (epcount >= 10 && season < 10)
                        {
                            file1.filename = Convert.ToString(folderpath + "\\" + name + " S0" + season + "E" + epcount + extention);
                        }

                        System.IO.File.Move(file, file1.ToString());
                        epcount++;
                    }
                }
                foreach (string x in Directory.EnumerateFiles(folderpath))
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine("Done. Would you like to continue(Y/N)?");
                continueloop = Convert.ToChar(Console.ReadLine());
                while (char.ToUpper(continueloop) != 'Y' && char.ToUpper(continueloop) != 'N')
                {
                    Console.WriteLine("Invalid entry please try again:");
                    continueloop = Convert.ToChar(Console.ReadLine());
                }
            }
        }
        public override string ToString()
        {
            return string.Format("test");
        }
    }
    class nfile
    {
        public string filename;
        public override string ToString()
        {
            return string.Format("{0}",filename);
        }

    }
}
