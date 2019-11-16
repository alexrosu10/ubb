import 'package:flutter/material.dart';
import 'database.dart';
import 'workoutDay.dart';
import 'exercise.dart';

void main() => runApp(ToDoApp());

class ToDoApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Workouts',
      theme: ThemeData(
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.purple,
      ),
      home: new ToDoList()
    );
  }
}

class ToDoList extends StatefulWidget {
  @override
  createState() => new ToDoListState();
}

class ToDoListState extends State<ToDoList> {
  DatabaseProvider dbProvider = new DatabaseProvider();
  int dayId = 0;

  Future<List<WorkoutDay>> getDays() async {
    return await dbProvider.getDays();
  }

  Future<List<Exercise>> getExercisesForDay(int dayId) async {
    return await dbProvider.getExercises(dayId);
  }

  void addExercise(Exercise exercise) async {
    if (exercise.text.length > 0) {
      await dbProvider.insertExercise(exercise);
      setState(() {});
    }
  }

  void addDay(WorkoutDay day) async {
    if (day.text.length > 0) {
      await dbProvider.insertDay(day);
      setState(() {});
    }
  }

  void removeExercise(int id) async {
    await dbProvider.deleteExercise(id);
    setState(() {});
  }

  void removeDay(int id) async {
    await dbProvider.deleteDay(id);
    setState(() {});
  }

  void removeUnused() {
    dbProvider.removeUnusedExercises();
  }

  void updateDay(WorkoutDay day) async {
    if (day.text.length > 0) {
      await dbProvider.updateDay(day);
      setState(() {});
    }
  }

  void updateExercise(Exercise exercise) async {
    if (exercise.text.length > 0) {
      await dbProvider.updateExercise(exercise);
      setState(() {});
    }
  }

  void promptRemoveDay(WorkoutDay day) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return new AlertDialog(
          title: new Text("Delete day"),
          actions: <Widget>[
            new FlatButton(
              child: new Text("CANCEL"),
              onPressed: () => Navigator.of(context).pop()
            ),
            new FlatButton(
              child: new Text("OK"),
              onPressed: () {
                removeDay(day.id);
                Navigator.of(context).pop();
              }
            )
          ]
        );
      }
    );
  }

  void promptRemoveExercise(Exercise exercise) {
    showDialog(
        context: context,
        builder: (BuildContext context) {
          return new AlertDialog(
              title: new Text("Delete exercise?"),
              actions: <Widget>[
                new FlatButton(
                    child: new Text("CANCEL"),
                    onPressed: () => Navigator.of(context).pop()
                ),
                new FlatButton(
                    child: new Text("OK"),
                    onPressed: () {
                      removeExercise(exercise.id);
                      Navigator.of(context).pop();
                    }
                )
              ]
          );
        }
    );
    setState(() {});
  }

  Widget buildList() {
    return FutureBuilder(
      builder: (builder, snapshot) {
        if (!snapshot.hasData) {
          return Center(child: CircularProgressIndicator());
        }
        List<WorkoutDay> items = snapshot.data;
        return new ListView.builder(
          itemBuilder: (context, index) {
            if (index < items.length) {
              return buildItem(items[index]);
            } else {
              return null;
            }
          }
        );
      },
      future: getDays()
    );
  }

  Widget buildExercisesForMainWindow(int dayId) {
    return FutureBuilder(
        builder: (builder, snapshot) {
          if (!snapshot.hasData) {
            return Center(child: CircularProgressIndicator());
          }
          List<Exercise> items = snapshot.data;
          return new ListView.builder(
            itemBuilder: (context, index) {
              if (index < items.length) {

                return new ListTile(
                  title: new Text(items[index].text),
                );
              } else {
                return null;
              }
            },
            shrinkWrap: true,
            physics: ClampingScrollPhysics()
          );
        },
        future: getExercisesForDay(dayId)
    );
  }

  Widget buildItem(WorkoutDay task) {
    return new ListTile(
      title: new Text(task.text),
      subtitle: buildExercisesForMainWindow(task.id),
      onTap: () => promptRemoveDay(task),
      onLongPress: () => pushUpdateScreen(task),
    );
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      appBar: new AppBar(
        title: new Text("My workouts")
      ),
      body: buildList(),
      floatingActionButton: new FloatingActionButton(
        onPressed: pushAddScreen,
        tooltip: "Add new workout",
        child: new Icon(Icons.add)
      )
    );
  }

  Widget buildExercise(Exercise exercise) {

    return new ListTile(
      title: new Text(exercise.text),
      onTap: () => promptRemoveExercise(exercise),
      onLongPress: () => pushUpdateExercise(exercise),
    );
  }

  Widget buildListExercises(int dayId) {
    return FutureBuilder(
        builder: (builder, snapshot) {
          if (!snapshot.hasData) {
            return Center(child: CircularProgressIndicator());
          }
          List<Exercise> items = snapshot.data;
          return new ListView.builder(
              itemBuilder: (context, index) {
                if (index < items.length) {

                  return buildExercise(items[index]);
                } else {
                  return null;
                }
              },
            shrinkWrap: true,
          );
        },
        future: getExercisesForDay(dayId)
    );
  }

  void addExerciseScreen(int dayId){
    Navigator.of(context).push(
        new MaterialPageRoute(
            builder: (context) {
              return new Scaffold(
                  appBar: new AppBar(
                      title: new Text("Add new exercise")
                  ),
                  body: new TextField(
                    autofocus: true,
                    onSubmitted: (val) {
                      addExercise(new Exercise(id: -1, text: val, dayId: dayId));
                      Navigator.pop(context);
                    },
                    decoration: new InputDecoration(
                        hintText: "Enter the new exercise here",
                        contentPadding: const EdgeInsets.all(16.0)
                    ),
                  )
              );
            }
        )
    );
    setState(() {});
  }

  void pushAddScreen() {
    dayId++;
    removeUnused();
    Navigator.of(context).push(
      new MaterialPageRoute(
        builder: (context) {
          return new Scaffold(
            appBar: new AppBar(
              title: new Text("Add new workout")
            ),
            body:
            new Column(
                mainAxisSize: MainAxisSize.max,
                children:
                    <Widget>[new TextField(
              autofocus: true,
              onSubmitted: (val) {
                addDay(new WorkoutDay(id: dayId, text: val));
                Navigator.pop(context);
              },
              decoration: new InputDecoration(
                hintText: "Enter the new day here",
                contentPadding: const EdgeInsets.all(16.0)
              ),
            ),
                      Expanded(child: buildListExercises(dayId))
                    ],
          ),
            floatingActionButton: new FloatingActionButton(
          onPressed: () => addExerciseScreen(dayId),
          tooltip: "Add new Exercise",
          child: new Icon(Icons.add))
          );
        }
      )
    );
  }

  void pushUpdateExercise(Exercise exercise) async {
    Navigator.of(context).push(
        new MaterialPageRoute(
            builder: (context) {
              return new Scaffold(
                  appBar: new AppBar(
                      title: new Text("Update exercise")
                  ),
                  body: new TextField(
                        controller: TextEditingController()..text = exercise.text,
                        autofocus: true,
                        onSubmitted: (val) {
                          updateExercise(new Exercise(id: exercise.id, text: val, dayId: exercise.dayId));
                          Navigator.pop(context);
                        },
                        decoration: new InputDecoration(
                            hintText: "Enter exercise here",
                            contentPadding: const EdgeInsets.all(16.0)
                        )
                    )
              );
            }
        )
    );
  }

  void pushUpdateScreen(WorkoutDay day) async {
    Navigator.of(context).push(
      new MaterialPageRoute(
        builder: (context) {
          return new Scaffold(
            appBar: new AppBar(
              title: new Text("Update day")
            ),
            body: Column(
                mainAxisSize: MainAxisSize.max,
                children:
                <Widget>[new TextField(
              controller: TextEditingController()..text = day.text,
              autofocus: true,
              onSubmitted: (val) {
                updateDay(new WorkoutDay(id: day.id, text: val));
                Navigator.pop(context);
              },
              decoration: new InputDecoration(
                hintText: "Enter day here",
                contentPadding: const EdgeInsets.all(16.0)
              )
            ),
                  Expanded(child: buildListExercises(day.id))
                ],
            ),
              floatingActionButton: new FloatingActionButton(
                  onPressed: () => addExerciseScreen(day.id),
                  tooltip: "Add new Exercise",
                  child: new Icon(Icons.add))
          );
        }
      )
    );
  }
}