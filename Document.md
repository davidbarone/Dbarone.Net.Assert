# Dbarone.Net.Assert
## T:Dbarone.Net.Assert.Assert
 Performs assertions. 

---
### M:Dbarone.Net.Assert.Assert.Equals(System.Object,System.Object,System.String)
 Checks an actual value equals an expected value. 
|Name | Description |
|-----|------|
|actual: |The actual object value.|
|expected: |The expected value.|
|actual_name: |The calling variable name.|

[T:AssertionException|T:AssertionException]: 
---
### M:Dbarone.Net.Assert.Assert.NotEquals(System.Object,System.Object,System.String)
 Checks an actual value does not equal an expected value. 
|Name | Description |
|-----|------|
|actual: |The actual object value.|
|expected: |The expected value.|
|actual_name: |The calling variable name.|

[T:AssertionException|T:AssertionException]: 
---
## T:AssertionException
 Standard exception thrown by all Assert failures. 

---
### M:AssertionException.#ctor(System.String)
 Constructor for the AssertionException class. 
|Name | Description |
|-----|------|
|message: |The assertion message being thrown.|
---
