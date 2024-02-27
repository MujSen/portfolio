import 'package:flutter/material.dart';

void main() {
  runApp(MyApp());
}

class Todo {
  final String id;
  String title;
  String description;
  bool completed;

  Todo({
    required this.id,
    required this.title,
    required this.description,
    this.completed = false,
  });
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Todo App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: TodoListScreen(),
    );
  }
}

class TodoListScreen extends StatefulWidget {
  @override
  _TodoListScreenState createState() => _TodoListScreenState();
}

class _TodoListScreenState extends State<TodoListScreen> {
  List<Todo> todos = [
    Todo(
      id: '1',
      title: 'Example Todo 1',
      description: 'This is an example todo 1.',
    ),
    Todo(
      id: '2',
      title: 'Example Todo 2',
      description: 'This is an example todo 2.',
    ),
    Todo(
      id: '3',
      title: 'Example Todo 3',
      description: 'This is an example todo 3.',
    ),
  ];

  TextEditingController _titleController = TextEditingController();
  TextEditingController _descriptionController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Todo List'),
      ),
      body: ReorderableListView(
        onReorder: (oldIndex, newIndex) {
          setState(() {
            if (newIndex > oldIndex) {
              newIndex -= 1;
            }
            final Todo todo = todos.removeAt(oldIndex);
            todos.insert(newIndex, todo);
          });
        },
        children: todos.map((todo) {
          return ListTile(
            key: Key(todo.id),
            title: Text(todo.title),
            subtitle: Text(todo.description),
            onTap: () {
              _editTodoDialog(todo);
            },
            trailing: IconButton(
              icon: Icon(Icons.delete),
              onPressed: () {
                _deleteTodoDialog(todo);
              },
            ),
          );
        }).toList(),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          _addTodoDialog();
        },
        child: Icon(Icons.add),
      ),
    );
  }

  void _addTodoDialog() {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Add Todo"),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(
                controller: _titleController,
                decoration: InputDecoration(labelText: 'Title'),
              ),
              TextField(
                controller: _descriptionController,
                decoration: InputDecoration(labelText: 'Description'),
              ),
            ],
          ),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("Cancel"),
            ),
            TextButton(
              onPressed: () {
                setState(() {
                  final newTodo = Todo(
                    id: DateTime.now().toString(),
                    title: _titleController.text,
                    description: _descriptionController.text,
                  );
                  todos.add(newTodo);
                });
                Navigator.of(context).pop();
                _titleController.clear();
                _descriptionController.clear();
              },
              child: Text("Add"),
            ),
          ],
        );
      },
    );
  }

  void _editTodoDialog(Todo todo) {
    _titleController.text = todo.title;
    _descriptionController.text = todo.description;
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Edit Todo"),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(
                controller: _titleController,
                decoration: InputDecoration(labelText: 'Title'),
              ),
              TextField(
                controller: _descriptionController,
                decoration: InputDecoration(labelText: 'Description'),
              ),
            ],
          ),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("Cancel"),
            ),
            TextButton(
              onPressed: () {
                setState(() {
                  todo.title = _titleController.text;
                  todo.description = _descriptionController.text;
                });
                Navigator.of(context).pop();
                _titleController.clear();
                _descriptionController.clear();
              },
              child: Text("Save"),
            ),
          ],
        );
      },
    );
  }

  void _deleteTodoDialog(Todo todo) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text("Confirm Delete"),
          content: Text("Are you sure you want to delete this todo?"),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: Text("Cancel"),
            ),
            TextButton(
              onPressed: () {
                setState(() {
                  todos.remove(todo);
                });
                Navigator.of(context).pop();
              },
              child: Text("Delete"),
            ),
          ],
        );
      },
    );
  }

  @override
  void dispose() {
    _titleController.dispose();
    _descriptionController.dispose();
    super.dispose();
  }
}
