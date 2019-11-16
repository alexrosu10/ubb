package com.example.workout

import android.content.ContentValues
import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper
import android.util.Log
import java.util.*
import kotlin.collections.ArrayList

class DatabaseHandler(context: Context) : SQLiteOpenHelper(context, DatabaseHandler.DB_NAME, null, DatabaseHandler.DB_VERSION) {

    override fun onCreate(db: SQLiteDatabase) {
        val CREATE_TABLE = "CREATE TABLE $TABLE_NAME_DAYS ($ID INTEGER PRIMARY KEY, $NAME TEXT);"
        val CREATE_EX = "CREATE TABLE $TABLE_NAME_EX ($ID INTEGER PRIMARY KEY, $NAME TEXT, $DID INTEGER);"
        db.execSQL(CREATE_TABLE)
        db.execSQL(CREATE_EX)
    }

    override fun onUpgrade(db: SQLiteDatabase, oldVersion: Int, newVersion: Int) {
        val DROP_TABLE = "DROP TABLE IF EXISTS $TABLE_NAME_DAYS"
        val DROP_EX = "DROP TABLE IF EXISTS $TABLE_NAME_EX"
        db.execSQL(DROP_TABLE)
        db.execSQL(DROP_EX)
        onCreate(db)
    }

    fun addEx(ex: Exercise): Int {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(NAME, ex.name)
        values.put(DID, ex.dayId)
        val _success = db.insert(TABLE_NAME_EX, null, values)
        db.close()
        Log.v("InsertedId", "$_success")
        return (Integer.parseInt("$_success"))
    }

    fun addDay(day: WorkoutDay): Int {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(NAME, day.name)
        val _success = db.insert(TABLE_NAME_DAYS, null, values)
        db.close()
        Log.v("InsertedId", "$_success")
        return (Integer.parseInt("$_success"))
    }

    fun getEx(_id: Int): Exercise {
        val ex = Exercise()
        val db = writableDatabase
        val selectQuery = "SELECT  * FROM $TABLE_NAME_EX WHERE $ID = $_id"
        val cursor = db.rawQuery(selectQuery, null)

        cursor?.moveToFirst()
        ex.id = Integer.parseInt(cursor.getString(cursor.getColumnIndex(ID)))
        ex.name = cursor.getString(cursor.getColumnIndex(NAME))
        ex.dayId = Integer.parseInt(cursor.getString(cursor.getColumnIndex(DID)))
        cursor.close()
        return ex
    }

    fun getDay(_id: Int): WorkoutDay {
        val day = WorkoutDay()
        val db = writableDatabase
        val selectQuery = "SELECT  * FROM $TABLE_NAME_DAYS WHERE $ID = $_id"
        val cursor = db.rawQuery(selectQuery, null)

        cursor?.moveToFirst()
        day.id = Integer.parseInt(cursor.getString(cursor.getColumnIndex(ID)))
        day.name = cursor.getString(cursor.getColumnIndex(NAME))
        cursor.close()
        return day
    }

    fun day(): List<WorkoutDay> {
        val dayList = ArrayList<WorkoutDay>()
        val db = writableDatabase
        val selectQuery = "SELECT  * FROM $TABLE_NAME_DAYS"
        val cursor = db.rawQuery(selectQuery, null)
        if (cursor != null) {
            if (cursor.moveToFirst()) {
                do {
                    val day = WorkoutDay()
                    day.id = Integer.parseInt(cursor.getString(cursor.getColumnIndex(ID)))
                    day.name = cursor.getString(cursor.getColumnIndex(NAME))
                    dayList.add(day)
                } while (cursor.moveToNext())
            }
        }
        cursor.close()
        return dayList
    }

    fun updateExercise(ex: Exercise): Boolean {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(NAME, ex.name)
        values.put(DID, ex.dayId)
        val _success = db.update(TABLE_NAME_EX, values, ID + "=?", arrayOf(ex.id.toString())).toLong()
        db.close()
        return Integer.parseInt("$_success") != -1
    }

    fun updateDay(day: WorkoutDay): Boolean {
        val db = this.writableDatabase
        val values = ContentValues()
        values.put(NAME, day.name)
        val _success = db.update(TABLE_NAME_DAYS, values, ID + "=?", arrayOf(day.id.toString())).toLong()
        db.close()
        return Integer.parseInt("$_success") != -1
    }

    fun getExForDay(_id: Int): List<Exercise>{
        val exs = ArrayList<Exercise>()
        val db = writableDatabase
        val selectQuery = "SELECT  * FROM $TABLE_NAME_EX WHERE $DID = $_id"
        val cursor = db.rawQuery(selectQuery, null)

        if (cursor != null) {
            if (cursor.moveToFirst()) {
                do {
                    val ex = Exercise()
                    ex.id = Integer.parseInt(cursor.getString(cursor.getColumnIndex(ID)))
                    ex.name = cursor.getString(cursor.getColumnIndex(NAME))
                    ex.dayId = Integer.parseInt(cursor.getString(cursor.getColumnIndex(DID)))
                    exs.add(ex)
                } while (cursor.moveToNext())
            }
        }
        cursor.close()
        return exs
    }

    fun deleteEx(_id: Int): Boolean {
        val db = this.writableDatabase
        val _success = db.delete(TABLE_NAME_EX, ID + "=?", arrayOf(_id.toString())).toLong()
        db.close()
        return (Integer.parseInt("$_success") != -1)
    }

    fun deleteDay(_id: Int): Boolean {
        val db = this.writableDatabase
        val _success = db.delete(TABLE_NAME_DAYS, ID + "=?", arrayOf(_id.toString())).toLong()
        val exs = getExForDay(_id)
        val ids = arrayListOf<String>()
        for(ex in exs){
            ids.add(ex.id.toString())
        }
        print("\n\n\n\n\n\n\n\n\n\n\n\n\nids:"+ids.toTypedArray()+"\n\n\n\n\n\n\n\n\n\n")
        for(id in ids) {
            val _success2 = db.delete(TABLE_NAME_EX, ID + "=?", arrayOf(id)).toLong()
        }
        db.close()
        return (Integer.parseInt("$_success") != -1)
    }

    fun deleteAllDays(): Boolean {
        val db = this.writableDatabase
        val _success = db.delete(TABLE_NAME_DAYS, null, null).toLong()
        val _success2 = db.delete(TABLE_NAME_EX, null, null).toLong()
        db.close()
        return (Integer.parseInt("$_success") != -1) && (Integer.parseInt("$_success") != -1)
    }

    companion object {
        private val DB_VERSION = 2
        private val DB_NAME = "Workouts"
        private val TABLE_NAME_DAYS = "Days"
        private val TABLE_NAME_EX = "Exercises"
        private val ID = "Id"
        private val NAME = "Name"
        private val DID = "DayId"
    }
}