class WorkoutDay {
  int id;
  String text;

  WorkoutDay({ this.id, this.text });

  factory WorkoutDay.fromMap(Map<String, dynamic> json) => new WorkoutDay(
    id: json["id"],
    text: json["text"]
  );

  Map<String, dynamic> toMap() => {
    "id": id,
    "text": text
  };

  Map<String, dynamic> toMapNoId() => {
    "text": text
  };
}