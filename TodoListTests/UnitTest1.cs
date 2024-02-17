using TodoListModels;

namespace TodoListTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TodoItem_SetProperties_ShouldSetCorrectly()
    {
        // Arrange
        var TODOITEM = new TodoItem();

        // Act
        TODOITEM.Id = 1;
        TODOITEM.Description = "test description";
        TODOITEM.CompletedDate = DateTime.Now;

        // Assert
        Assert.AreEqual(1, TODOITEM.Id);
        Assert.AreEqual("test description", TODOITEM.Description);
        Assert.IsNotNull(TODOITEM.CompletedDate);
    }

    [TestMethod]
    public void TodoItem_Id_DefaultValue_ShouldBeZero()
    {
        // Arrange
        var TODOITEM = new TodoItem();

        // Assert
        Assert.AreEqual(0, TODOITEM.Id);
    }  

    [TestMethod]
    public void TodoItem_Description_DefaultValue_ShouldBeNull()
    {
        // Arrange
        var TODOITEM = new TodoItem();

        // Assert
        Assert.IsNull(TODOITEM.Description);
    } 

    [TestMethod]
    public void TodoItem_CompletedDate_DefaultValue_ShouldBeNull()
    {
        // Arrange
        var TODOITEM = new TodoItem();

        // Assert
        Assert.IsNull(TODOITEM.CompletedDate);
    }
}