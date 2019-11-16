import 'dart:async';

import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';
import 'workoutDay.dart';
import 'exercise.dart';

class DatabaseProvider {
  Future<Database> getDatabase() async {
    return openDatabase(
      join(await getDatabasesPath(), "workouts.db"),
      onCreate: (db, version) async {
        await db.execute(
          "CREATE TABLE days(id INTEGER PRIMARY KEY, text TEXT)"
        );
        await db.execute(
            "CREATE TABLE exercises(id INTEGER PRIMARY KEY, text TEXT, dayId INTEGER)"
        );
      },
      version: 2
    );
  }

  void removeUnusedExercises() async {
    final Database db = await getDatabase();
    final List<Map<String, dynamic>> maps = await db.query("exercises");
    List<Exercise> exs= List.generate(maps.length, (i) {
      return Exercise(
          id: maps[i]["id"],
          text: maps[i]["text"],
          dayId: maps[i]["dayId"]
      );
    });
    List<int> toBeRemoved = new List();
    for(var ex in exs){
      List<Map<String,dynamic>> days = await db.query("days",
      where: "id = ?",
      whereArgs: [ex.dayId]);
      if(days.isEmpty){
        toBeRemoved.add(ex.id);
      }
    }
    for(int id in toBeRemoved){
      await deleteExercise(id);
    }
  }

  Future<List<Exercise>> getExercises(int dayId) async {
    final Database db = await getDatabase();
    final List<Map<String, dynamic>> maps = await db.query(
        "exercises",
        where: "dayId = ?",
        whereArgs: [dayId]
    );
    return List.generate(maps.length, (i) {
      return Exercise(
          id: maps[i]["id"],
          text: maps[i]["text"],
          dayId: maps[i]["dayId"]
      );
    });
  }

  Future<List<WorkoutDay>> getDays() async {
    final Database db = await getDatabase();
    final List<Map<String, dynamic>> maps = await db.query("days");
    return List.generate(maps.length, (i) {
      return WorkoutDay(
        id: maps[i]["id"],
        text: maps[i]["text"]
      );
    });
  }

  Future<void> insertExercise(Exercise exercise) async {
    final Database db = await getDatabase();
    await db.insert(
        "exercises",
        exercise.toMapNoId(),
        conflictAlgorithm: ConflictAlgorithm.replace
    );
  }

  Future<void> insertDay(WorkoutDay day) async {
    final Database db = await getDatabase();
    await db.insert(
        "days",
        day.toMap(),
        conflictAlgorithm: ConflictAlgorithm.replace
    );
  }

  Future<void> updateExercise(Exercise exercise) async {
    final Database db = await getDatabase();
    await db.update(
        "exercises",
        exercise.toMap(),
        where: "id = ?",
        whereArgs: [exercise.id]
    );
  }

  Future<void> updateDay(WorkoutDay day) async {
    final Database db = await getDatabase();
    await db.update(
      "days",
      day.toMap(),
      where: "id = ?",
      whereArgs: [day.id]
    );
  }

  Future<void> deleteExercise(int id) async {
    final Database db = await getDatabase();
    await db.delete(
        "exercises",
        where: "id = ?",
        whereArgs: [id]
    );
  }

  Future<void> deleteDay(int id) async {
    final Database db = await getDatabase();
    await db.delete(
      "days",
      where: "id = ?",
      whereArgs: [id]
    );
    await db.delete(
      "exercises",
      where: "dayId = ?",
    );
  }
}