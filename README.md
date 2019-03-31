# UnityFactoryBot
UnityFactoryBot is a factory library for Unity C#. It supports associations and the use of Data Class for generating attributes.

# Installation

Since unitypackage is in release tag, install it. https://github.com/TakuKobayashi/UnityFactoryBot/releases

# Usage
Here's the crash course:

```C#
using FactoryBot;

public class User{
    public string name;
    public int level;
}

User user = Factory.Build<User>(new Dictionary<string, object>() {
  { "name", "test" },
  { "level", 10 }
});
// equal 'test'
Debug.Log(user.name)
// equal 10
Debug.Log(user.level)
```

# Defining Factories
Define factories using the ```Factory.Define<T>()``` method.

For example:
```C#

using FactoryBot;

public class User{
    public string name;
    public int level;
}

DefinedFactory<User> definedUser = Factory.Define<User>(new Dictionary<string, object>() {
  { "name", "test" },
  { "level", 10 }
});

User user = definedUser.Build();
// equal 'test'
Debug.Log(user.name)
// equal 10
Debug.Log(user.level)
```

# Others
See the Exmaples(```Assets/FactoryBot/Examples/```).
They are unit tests.

# License
This software is licensed under the MIT License.