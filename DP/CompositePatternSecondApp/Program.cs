using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositePatternSecondApp.Model;
namespace CompositePatternSecondApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder movie = new Folder("Movie");
            Folder actionFolder = new Folder("Action");
            Folder comedyFolder = new Folder("Comedy");
            Folder actionComedyFolder = new Folder("Action-Comedy");

            File abcFile = new File("abc",100,"avi");
            File defFile = new File("def", 100, "mp4");
            File mnoFile = new File("mno", 100, "avi");
            File pqrFile = new File("pqr", 100, "mp4");
            File lmnFile = new File("lmn", 100, "avi");
            File xyzFile = new File("xyz", 100, "mp4");

            movie.AddChildren(actionFolder);
            actionFolder.AddChildren(actionComedyFolder);
            movie.AddChildren(comedyFolder);

            actionFolder.AddChildren(abcFile);
            actionFolder.AddChildren(defFile);
            actionFolder.AddChildren(pqrFile);
            comedyFolder.AddChildren(mnoFile);
            comedyFolder.AddChildren(lmnFile);
            comedyFolder.AddChildren(xyzFile);

            movie.Display(new StringBuilder());
            Console.ReadLine();

        }
    }
}
