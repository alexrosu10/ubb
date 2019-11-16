package com.example.workout

import android.content.Context
import android.content.Intent
import android.os.Build
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import android.widget.TextView
import androidx.annotation.RequiresApi
import androidx.core.content.ContextCompat
import androidx.recyclerview.widget.RecyclerView
import com.example.workout.DatabaseHandler

import java.util.ArrayList

class TaskRecyclerAdapter(daysList: List<WorkoutDay>, internal var context: Context) : RecyclerView.Adapter<TaskRecyclerAdapter.TaskViewHolder>() {

    var dbHandler: DatabaseHandler? = null
    internal var daysList: List<WorkoutDay> = ArrayList()
    init {
        this.daysList = daysList
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TaskViewHolder {
        val view = LayoutInflater.from(context).inflate(R.layout.list_item_day, parent, false)
        return TaskViewHolder(view)
    }

    @RequiresApi(Build.VERSION_CODES.JELLY_BEAN)
    override fun onBindViewHolder(holder: TaskViewHolder, position: Int) {
        dbHandler = DatabaseHandler(context)

        val tasks = daysList[position]
        var listExs: List<Exercise> = (dbHandler as DatabaseHandler).getExForDay(tasks.id)
        var str: String = tasks.name
        if(listExs.size>0){
            for(ex in listExs){
            str += "\n    -"+ex.name
            }
        }
        holder.name.text = str

        holder.itemView.setOnClickListener {
            val i = Intent(context, AddOrEditActivity::class.java)
            i.putExtra("Mode", "E")
            i.putExtra("Id", tasks.id)
            i.flags = Intent.FLAG_ACTIVITY_NEW_TASK
            context.startActivity(i)
        }
    }

    override fun getItemCount(): Int {
        return daysList.size
    }

    inner class TaskViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        var name: TextView = view.findViewById(R.id.tvName) as TextView
        var list_item: LinearLayout = view.findViewById(R.id.list_item) as LinearLayout
    }

}