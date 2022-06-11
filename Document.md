# Dbarone.Net.Assertions


>## T:Dbarone.Net.Assertions.Assert

 Applies assertions to the state of objects. The assertions are evaluated in all configurations (debug and release). If the assertion succeeds, the code continues. If the assertion fails, an `AssertionException` is thrown. 

---
### M:Dbarone.Net.Assertions.Assert.Equals(System.Object,System.Object,System.String)
 Checks an actual value equals an expected value. 
|Name | Description |
|-----|------|
|actual: |The actual object value.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not equal to the expected value.

---
### M:Dbarone.Net.Assertions.Assert.NotEquals(System.Object,System.Object,System.String)
 Checks an actual value does not equal an expected value. 
|Name | Description |
|-----|------|
|actual: |The actual object value.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is equal to the expected value.

---
### M:Dbarone.Net.Assertions.Assert.Null(System.Object,System.String)
 Checks that an object reference should be null. 
|Name | Description |
|-----|------|
|obj: |The object to check.|
|obj_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the object is not null.

---
### M:Dbarone.Net.Assertions.Assert.NotNull(System.Object,System.String)
 Checks that an object reference should not be null. 
|Name | Description |
|-----|------|
|obj: |The object to check.|
|obj_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the object is null.

---
### M:Dbarone.Net.Assertions.Assert.True(System.Boolean,System.String)
 Asserts an expression is truthy. 
|Name | Description |
|-----|------|
|expr: |The expression to evaulate. Must return a boolean result.|
|expr_name: |The expression name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the expression resolves to false.

---
### M:Dbarone.Net.Assertions.Assert.False(System.Boolean,System.String)
 Asserts an expression is falsy. 
|Name | Description |
|-----|------|
|expr: |The expression to evaulate. Must return a boolean result.|
|expr_name: |The expression name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the expression resolves to true.

---
### M:Dbarone.Net.Assertions.Assert.Flag(System.Enum,System.Enum,System.String)
 Asserts that an enum value has a flag set. 
|Name | Description |
|-----|------|
|actual: |The actual value.|
|flag: |The flag to check.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the enum value does not have the flag set.

---
### M:Dbarone.Net.Assertions.Assert.NotFlag(System.Enum,System.Enum,System.String)
 Asserts that an enum value does not have a flag set. 
|Name | Description |
|-----|------|
|actual: |The actual value.|
|flag: |The flag to check.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the enum value does not have the flag set.

---
### M:Dbarone.Net.Assertions.Assert.GreaterThan``1(``0,``0,System.String)
 Asserts that a value is greater than an expected value. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not greater than the expected value.

---
### M:Dbarone.Net.Assertions.Assert.NotGreaterThan``1(``0,``0,System.String)
 Asserts that a value is not greater than an expected value. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is greater than the expected value.

---
### M:Dbarone.Net.Assertions.Assert.LessThan``1(``0,``0,System.String)
 Asserts that a value is less than an expected value. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not less than the expected value.

---
### M:Dbarone.Net.Assertions.Assert.NotLessThan``1(``0,``0,System.String)
 Asserts that a value is not less than an expected value. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is less than the expected value.

---
### M:Dbarone.Net.Assertions.Assert.Between``1(``0,``0,``0,System.String)
 Asserts that a value is between 2 values. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|min: |The minimum value.|
|max: |The maximum value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is between the min and max values.

---
### M:Dbarone.Net.Assertions.Assert.NotBetween``1(``0,``0,``0,System.String)
 Asserts that a value is between 2 values. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|min: |The minimum value.|
|max: |The maximum value.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is between the min and max values.

---
### M:Dbarone.Net.Assertions.Assert.IsType(System.Object,System.Type,System.String)
 Asserts that an actual value is a specific type. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected type.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not the specified type.

---
### M:Dbarone.Net.Assertions.Assert.NotIsType(System.Object,System.Type,System.String)
 Asserts that an actual value is not a specific type. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected type.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not the specified type.

---
### M:Dbarone.Net.Assertions.Assert.AssignableFrom(System.Object,System.Type,System.String)
 Asserts that an actual value is assignable from a specific type. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected type.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is not assignable from the specified type.

---
### M:Dbarone.Net.Assertions.Assert.NotAssignableFrom(System.Object,System.Type,System.String)
 Asserts that an actual value is not assignable from a specific type. 
|Name | Description |
|-----|------|
|actual: |The value to assert.|
|expected: |The expected type.|
|actual_name: |The calling variable name (do not use - this is automatically populated by the library).|

Exception thrown: [T:Dbarone.Net.Assertions.AssertionException](#T:Dbarone.Net.Assertions.AssertionException): Throws an exception if the actual value is assignable from the specified type.

---


>## T:Dbarone.Net.Assertions.AssertionException

 Standard exception thrown by all Assert failures. 

---
### M:Dbarone.Net.Assertions.AssertionException.#ctor(System.String)
 Constructor for the AssertionException class. 
|Name | Description |
|-----|------|
|message: |The assertion message being thrown.|

---
