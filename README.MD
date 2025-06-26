Implementation of Specification DDD pattern

Usage:
Create your own Specification

```C#
public sealed class UserSpecification(string name) : CompositeSpecification<User>
{
    public override Expression<Func<User, bool>> IsSatisfiedByExpression() => user => user.Name == name;
}

//User class as reference
public class User
{
    public string Name { get; set; }
}
```

Then in your code use this specification

```C#
public class Examples
{
    //Filters a collection
    public IReadonlyCollection<User> Filter(string nameToSearch)
    {
        var usersBySearch = users.Where(new UserSpecification(nameToSearch).IsSatisfiedBy).ToList();

        //some your code
        return usersBySearch;
    }

    //Defines if the user is satisfy the expression
    public bool IsUserNameSergei(User user)
    {
        //some your code
        return new UserSpecification("Sergei").IsSatisfiedBy(user);
    }
}
```

To Use negative Specification use
```C#
public class Examples
{
    //Filters a collection
    public IReadonlyCollection<User> Filter(string nameNotToSearch)
    {
        var usersBySearch = users.Where(new UserSpecification(nameNotToSearch).Not().IsSatisfiedBy).ToList();

        //some your code
        return usersBySearch;
    }

    //Defines if the user is satisfy the expression
    public bool IsUserNameNotSergei(User user)
    {
        //some your code
        return new UserSpecification("Sergei").Not().IsSatisfiedBy(user);
    }
}
```

Or to use Several Specifications
```C#
public class Examples
{
    //Filters a collection
    public IReadonlyCollection<User> Filter(string nameNotToSearch)
    {
        var defaultName = "Frodo";

        //This should return all users with names nameNotToSearch and Frodo
        var usersBySearch = users.Where(new UserSpecification(nameNotToSearch).Or(new UserSpecification(defaultName)).IsSatisfiedBy).ToList();

        //some your code
        return usersBySearch;
    }
}
```