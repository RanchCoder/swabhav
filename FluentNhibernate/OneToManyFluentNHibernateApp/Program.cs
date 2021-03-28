using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManyFluentNHibernateApp
{
    class Program
    {
        const string SCI_TECH = "Science&Tech";
        const string DRAMA = "DRAMA";
        static void Main(string[] args)
        {
           // FindPost();
           // FetchCategoryAndPost();
            FetchPostAndCategoryDetail();
            //InsertCategory(SCI_TECH);
           // InsertPost("Apollo lander lands on mars",SCI_TECH);
            Console.ReadLine();
        }


        public static void FetchCategoryAndPost()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var post = session.CreateCriteria<Post>();
                    var category = session.CreateCriteria<Category>();
          var result =          session.Query<Category>()
       .Join(session.Query<Post>(), cat => cat.Id, pst => pst.Category.Id, (cat, pst) => new
       {
           categoryId = cat.Id,
           categoryName = cat.Name,
           postName = pst.Title,

       }).Where(x=> x.categoryId == 1);
       
                    foreach (var cp in result)
                    {
                        Console.WriteLine($"category id : {cp.categoryId} , category Name = {cp.categoryName} , post Name = {cp.postName}");
                    }
                }
            }

        }

        public static void FetchPostAndCategoryDetail()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var post = session.CreateCriteria<Post>();
                    var category = session.CreateCriteria<Category>();
                    var result = session.Query<Category>()
                 .Join(session.Query<Post>(), cat => cat.Id, pst => pst.Category.Id, (cat, pst) => new
                 {
                     categoryId = cat.Id,
                     categoryName = cat.Name,
                     postName = pst.Title,

                 }).OrderBy(x=>x.categoryName);

                    foreach (var cp in result)
                    {
                        Console.WriteLine($"category id : {cp.categoryId} , category Name = {cp.categoryName} , post Name = {cp.postName}");
                    }
                }
            }

        }
        public static void FindPost()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var data = session.Query<Category>().Where(x => x.Id == 1);
                    foreach(var cp in data)
                    {
                        Console.WriteLine($"category id : {cp.Id} , category Name = {cp.Name}");
                    }
                }
            }
        }

        public static void InsertCategory(string categoryName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                   

                    var categoryType = new Category
                    {
                        Name = categoryName,
                    };              

                    session.Save(categoryType);
                    transaction.Commit();
                    Console.WriteLine($"Category {categoryName} added.");
                }
                Console.ReadKey();
            }
        }

        public static void InsertPost(string postName,string categoryName)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var categories = session.CreateCriteria<Category>().List<Category>();
                    int id = 0;
                    foreach(var cat in categories)
                    {
                        if(cat.Name == categoryName)
                        {
                            id = cat.Id;
                        }
                    }
                    var category = session.Get<Category>(id);

                    

                    var post = new Post
                    {
                        Title = postName,
                    };

                    post.Category = category;

                    session.Save(post);
                    transaction.Commit();
                    Console.WriteLine($"Post {postName} added.");
                }
                Console.ReadKey();
            }
        }
    }
}
