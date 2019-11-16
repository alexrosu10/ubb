package com.example.workout

import android.content.Intent
import android.os.Bundle
import android.view.Menu
import android.view.MenuItem
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.Toolbar
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.floatingactionbutton.FloatingActionButton

class MainActivity : AppCompatActivity() {

    var dayRecyclerAdapter: TaskRecyclerAdapter? = null;
    var fab: FloatingActionButton? = null
    var recyclerView: RecyclerView? = null
    var dbHandler: DatabaseHandler? = null
    var listDays: List<WorkoutDay> = ArrayList<WorkoutDay>()
    var linearLayoutManager: LinearLayoutManager? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        initViews()
        initOperations()
        //initDB()
    }

    fun initDB() {
        dbHandler = DatabaseHandler(this)
        listDays = (dbHandler as DatabaseHandler).day()
        dayRecyclerAdapter = TaskRecyclerAdapter(daysList = listDays, context = applicationContext)
        (recyclerView as RecyclerView).adapter = dayRecyclerAdapter
    }

    fun initViews() {
        val toolbar = findViewById(R.id.toolbar) as Toolbar
        setSupportActionBar(toolbar)
        fab = findViewById(R.id.fab) as FloatingActionButton
        recyclerView = findViewById(R.id.recycler_view) as RecyclerView
        dayRecyclerAdapter = TaskRecyclerAdapter(daysList = listDays, context = applicationContext)
        linearLayoutManager = LinearLayoutManager(applicationContext)
        (recyclerView as RecyclerView).layoutManager = linearLayoutManager
    }

    fun initOperations() {
        fab?.setOnClickListener { view ->
            val i = Intent(applicationContext, AddOrEditActivity::class.java)
            i.putExtra("Mode", "A")
            i.putExtra("Ex","NO")
            startActivity(i)
        }
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        menuInflater.inflate(R.menu.menu_main, menu)
        return true
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        val id = item.itemId
        if (id == R.id.action_delete) {
            val dialog = AlertDialog.Builder(this).setTitle("Info").setMessage("Click 'YES' Delete All Days")
                .setPositiveButton("YES", { dialog, i ->
                    dbHandler!!.deleteAllDays()
                    initDB()
                    dialog.dismiss()
                })
                .setNegativeButton("NO", { dialog, i ->
                    dialog.dismiss()
                })
            dialog.show()
            return true
        }
        return super.onOptionsItemSelected(item)
    }

    override fun onResume() {
        super.onResume()
        initDB()
    }
}
