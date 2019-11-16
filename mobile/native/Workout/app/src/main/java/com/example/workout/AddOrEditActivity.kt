package com.example.workout

import android.content.Intent
import android.os.Bundle
import android.view.MenuItem
import android.view.View
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.floatingactionbutton.FloatingActionButton
import com.google.android.material.textfield.TextInputEditText
import com.google.android.material.textfield.TextInputLayout
import kotlinx.android.synthetic.main.activity_add_edit.*

class AddOrEditActivity : AppCompatActivity() {

    var exRecyclerAdapter: ExerciseRecyclerAdapter? = null
    var dbHandler: DatabaseHandler? = null
    var recyclerView: RecyclerView? = null
    var linearLayoutManager: LinearLayoutManager? = null
    var listExs: List<Exercise> = ArrayList<Exercise>()
    var isEditMode = false
    var isEx = false

    public override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_add_edit)
        supportActionBar?.setDisplayHomeAsUpEnabled(true)
        initDB()
        if(!isEx) {
            initOperations()
        }
        else {
            initOperationsEx()
        }
    }

    private fun refreshList(){
        listExs = (dbHandler as DatabaseHandler).getExForDay(intent.getIntExtra("Id",0))
        recyclerView = findViewById<RecyclerView>(R.id.recycler_view_ex)
        exRecyclerAdapter = ExerciseRecyclerAdapter(exList= listExs,context= applicationContext)
        linearLayoutManager = LinearLayoutManager(applicationContext)
        (recyclerView as RecyclerView).adapter = exRecyclerAdapter
        (recyclerView as RecyclerView).layoutManager = linearLayoutManager
    }

    private fun initDB() {
        dbHandler = DatabaseHandler(this)
        btn_delete.visibility = View.INVISIBLE
        if (intent != null && intent.getStringExtra("Mode") == "E") {
            if(intent.getStringExtra("Ex")!="EX") {
                isEditMode = true
                refreshList()
                val days: WorkoutDay = dbHandler!!.getDay(intent.getIntExtra("Id", 0))
                input_name.setText(days.name)
                btn_delete.visibility = View.VISIBLE
            }
            else{
                isEditMode = true
                isEx = true
                btn_add_ex.visibility = View.GONE
                val ex: Exercise = dbHandler!!.getEx(intent.getIntExtra("Id",0))
                input_name.setText(ex.name)
                btn_delete.visibility = View.VISIBLE
            }
        }
        else if(intent != null && intent.getStringExtra("Ex") == "EX"){
            isEx = true
            btn_add_ex.visibility = View.GONE
        }
        else{
            btn_add_ex.visibility = View.GONE
        }
    }

    private fun initOperationsEx() {
        btn_save.setOnClickListener({
            var succ: Int = -1
            var success: Boolean = false
            if (!isEditMode) {
                val ex: Exercise = Exercise()
                ex.name = input_name.text.toString()
                ex.dayId = intent.getIntExtra("DId",0)
                succ = dbHandler?.addEx(ex) as Int
            } else {
                val ex: Exercise = Exercise()
                ex.id = intent.getIntExtra("Id", 0)
                ex.name = input_name.text.toString()
                ex.dayId = intent.getIntExtra("DId",0)
                success = dbHandler?.updateExercise(ex) as Boolean
            }

            if (success && (succ != -1))
                finish()
        })

        btn_delete.setOnClickListener({
            val dialog = AlertDialog.Builder(this).setTitle("Info").setMessage("Click 'YES' Delete the Exercise.")
                .setPositiveButton("YES", { dialog, i ->
                    val success = dbHandler?.deleteEx(intent.getIntExtra("Id", 0)) as Boolean
                    if (success)
                        finish()
                    dialog.dismiss()
                })
                .setNegativeButton("NO", { dialog, i ->
                    dialog.dismiss()
                })
            dialog.show()
        })
    }

    private fun initOperations() {
        btn_save.setOnClickListener({
            var succ: Int = -1
            var success: Boolean = false
            if (!isEditMode) {
                val day: WorkoutDay = WorkoutDay()
                day.name = input_name.text.toString()
                succ = dbHandler?.addDay(day) as Int
            } else {
                val day: WorkoutDay = WorkoutDay()
                day.id = intent.getIntExtra("Id", 0)
                day.name = input_name.text.toString()
                success = dbHandler?.updateDay(day) as Boolean
            }

            if (success && (succ != -1))
                finish()
        })

        btn_delete.setOnClickListener({
            val dialog = AlertDialog.Builder(this).setTitle("Info").setMessage("Click 'YES' Delete the Day.")
                .setPositiveButton("YES", { dialog, i ->
                    val success = dbHandler?.deleteDay(intent.getIntExtra("Id", 0)) as Boolean
                    if (success)
                        finish()
                    dialog.dismiss()
                })
                .setNegativeButton("NO", { dialog, i ->
                    dialog.dismiss()
                })
            dialog.show()
        })

        btn_add_ex.setOnClickListener({
                view ->
            val i = Intent(applicationContext, AddOrEditActivity::class.java)
            i.putExtra("Mode", "A")
            i.putExtra("Ex","EX")
            i.putExtra("DId",intent.getIntExtra("Id",0))
            startActivity(i)
            refreshList()
        })
    }

    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        val id = item.itemId
        if (id == android.R.id.home) {
            finish()
            return true
        }
        return super.onOptionsItemSelected(item)
    }
}