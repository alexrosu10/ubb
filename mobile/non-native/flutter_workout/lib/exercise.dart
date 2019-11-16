class Exercise {
  int id;
  String text;
  int dayId;

  Exercise({ this.id, this.text, this.dayId });

  factory Exercise.fromMap(Map<String, dynamic> json) => new Exercise(
      id: json["id"],
      text: json["text"],
      dayId: json["dayId"]
  );

  Map<String, dynamic> toMap() => {
    "id": id,
    "text": text,
    "dayId": dayId
  };

  Map<String, dynamic> toMapNoId() => {
    "text": text,
    "dayId": dayId
  };
}