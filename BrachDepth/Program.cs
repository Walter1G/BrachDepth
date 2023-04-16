using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrachDepth
{   
    class Program
    {
        static void Main(string[] args)
        {
            //Create the main branch, also create the sub branches(1-4)
            Branch MainBranch = new Branch(); 
            Branch branch1 = new Branch();
            Branch branch2 = new Branch();
            Branch branch3 = new Branch();
            Branch branch4 = new Branch();
            Branch branch5 = new Branch();

            //add branch 1 and 2 to the main brach
            MainBranch.AddBranch(branch1); 
            MainBranch.AddBranch(branch2);

            //add branch 3&4 to branch 1
            branch1.AddBranch(branch3);
            branch1.AddBranch(branch4);

            //add branch 5 to branch 4
            branch4.AddBranch(branch5);

            
            //Calculate the depth
            int depth = MainBranch.GetDepth();
            Console.WriteLine("Depth: " + depth);
            
            //prevent the console window from imediately shutting down after the result
           Console.ReadKey();
        }
    }

    class Branch
    {
        
        private List<Branch> branches;

        //with each brach create it's branch's list
        public Branch()
        {
            this.branches = new List<Branch>();
        }

        //to add branch to the list
        public void AddBranch(Branch branch)
        {
            this.branches.Add(branch);
        }

        public int GetDepth()
        {
            if (this.branches.Count == 0)
            {
                return 1;
            }
            int maxDepth = 0;
            foreach (Branch branch in this.branches)
            {
                int depth = branch.GetDepth();
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }
            return maxDepth + 1;
        }
    }

    


}
