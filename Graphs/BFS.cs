/*
 * Предположим, что нам нужно найти ближайшего
 * человека имеющего некоторый флаг.
 * Используем поиск в ширину(BFS).
 * Данные будем хранить в виде направленного графа, где
 * вершины - это люди, а рёбра указывают на их друзей (вершины).
 */

using System;

namespace Graphs;

public class BFS
{
    private Queue<User> _users = new();

    private static Random _random = new();

    private static bool _userWasFlagged = false;

    private void GenerateFriends(User user)
    {
        user.Friends = new List<User>(_random.Next(5));
        
        for (int i = 0; i < user.Friends.Capacity; i++)
        {
            user.Friends.Add(new User {Name = Guid.NewGuid()});
            if (!_userWasFlagged && _random.Next(10) == 3)
            {
                user.Friends[i].Flag = true;
                _userWasFlagged = true;
            }
        }
    }
    
    public void Fill()
    {
        for (int i = 0; i < 10; i++)
        {
            User main = new User {Name = Guid.NewGuid()};

            GenerateFriends(main);

            main.Friends.ForEach(GenerateFriends);

            _users.Enqueue(main);
        }
    }

    public (bool flag, User? user) Run()
    {
        while (_users.Count != 0)
        {
            User user = _users.Dequeue();
            user.WasChecked = true;
            if (user.Flag)
            {
                return (true, user);
            }

            // user.friends.ForEach(u => _users.Enqueue(u));
            if (user.Friends != null)
            {
                foreach (var friend in user.Friends)
                {
                    if (!friend.WasChecked)
                    {
                        _users.Enqueue(friend);
                    }
                }
            }
        }

        return (false, null);
    }
}

public class User
{
    public Guid Name { get; set; }

    public bool Flag { get; set; } = false;

    public bool WasChecked { get; set; } = false;

    public List<User> Friends { get; set; }
}