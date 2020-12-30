using System;
using System.Collections.Generic;
using System.Text;

namespace CLASSROOM_EXERCISE_MODULE_2
{
    class Forum
    {
        private MyList<Post> _posts = new MyList<Post>();

        internal MyList<Post> Posts { get => _posts; set => _posts = value; }

        public Forum()
        {

        }

        public bool Add(Post newPost)
        {
            if (Posts.Add(newPost) >= 0)
            {
                return true;
            }
            else return false;
        }

        public bool UpdateContent(int id, string newContent)
        {
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].Id == id)
                {
                    Posts[i].Content = newContent;
                    return true;
                }
            }
            return false;
        }

        public bool RemovePostFromId(int id)
        {
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].Id == id)
                {
                    Posts.Remove(Posts[i]);
                    return true;
                }
            }
            return false;
        }
        public string ShowAllPosts()
        {
            string result = "";
            for (int i = 0; i < Posts.Count; i++)
            {
                result += Posts[i].Display() + "\n";
            }
            return result;
        }

        public string SearchPost(string author, string title)
        {
            string result = "";
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].Author.Contains(author) || Posts[i].Title.ToLower().Contains(title))
                {
                    result += Posts[i].Display() + "\n";
                }
            }
            return result;
        }

        public int SearchPostWithId(int id)
        {
            for (int i = 0; i < Posts.Count; i++)
            {
                if (Posts[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
