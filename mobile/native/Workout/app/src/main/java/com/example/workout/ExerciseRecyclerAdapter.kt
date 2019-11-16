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
import androidx.recyclerview.widget.RecyclerView

import java.util.ArrayList

class ExerciseRecyclerAdapter(exList: List<Exercise>, internal var context: Context) : RecyclerView.Adapter<ExerciseRecyclerAdapter.TaskViewHolder>() {

    internal var exList: List<Exercise> = ArrayList()
    init {
        this.exList = exList
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TaskViewHolder {
        val view = LayoutInflater.from(context).inflate(R.layout.list_item_day, parent, false)
        return TaskViewHolder(view)
    }

    @RequiresApi(Build.VERSION_CODES.JELLY_BEAN)
    override fun onBindViewHolder(holder: TaskViewHolder, position: Int) {
        val tasks = exList[position]
        holder.name.text = tasks.name

        holder.itemView.setOnClickListener {
            val i = Intent(context, AddOrEditActivity::class.java)
            i.putExtra("Mode", "E")
            i.putExtra("Id", tasks.id)
            i.putExtra("DId",tasks.dayId)
            i.putExtra("Ex", "EX")
            i.flags = Intent.FLAG_ACTIVITY_NEW_TASK
            context.startActivity(i)
        }
    }

    override fun getItemCount(): Int {
        return exList.size
    }

    inner class TaskViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        var name: TextView = view.findViewById(R.id.tvName) as TextView
        var list_item: LinearLayout = view.findViewById(R.id.list_item) as LinearLayout
    }

}