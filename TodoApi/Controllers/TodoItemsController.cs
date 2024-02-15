using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TodoAPI.Models;
using TodoListModels;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemsController : ControllerBase
{
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems/NoCompletedDate
        [HttpGet("NoCompletedDate")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItemsWithNoCompletedDate()
        {
            var todoItems = await _context.TodoItems
                .Where(item => item.CompletedDate == null)
                .ToListAsync();

            if (todoItems == null || !todoItems.Any())
            {
                return NotFound();
            }

            return todoItems;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }   

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

         // POST: api/TodoItems/Complete/{id}
        [HttpPost("Complete/{id}")]
        public async Task<IActionResult> CompleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.CompletedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return NoContent();
        }

}
