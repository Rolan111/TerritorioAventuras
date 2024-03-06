using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    public class Answer
    {
        public string answer { get; private set; }
        public bool isCorrect { get; private set; }

        public Answer(string answer, bool isCorrect)
        {
            this.answer = answer;
            this.isCorrect = isCorrect;
        }

    }

    public class Question
    {
        public string question { get; private set; }
        public List<Answer> answers { get; private set; }

        public Question(string question, List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
        }
    }

    public List<Question> CreateQuestionList()
    {
        List<Question> list = new()
        {
            new(question: "1. Te encuentras en el parque de Caldas en Popay�n con un amigo, ustedes deciden ir al observatorio y en el cielo nocturno con el telescopio, observar las luces en el cielo y se dan cuenta que, de las 8 luces alumbrantes, 3 son estrellas. De las luces <b>�Cu�ntas luces no eran estrellas?</b>", answers: new()
            {
                new Answer(answer: "8 luces no eran estrellas", isCorrect: false),
                new Answer(answer: "5 luces no eran estrellas", isCorrect: true),
                new Answer(answer: "3 luces no eran estrellas", isCorrect: false),
                new Answer(answer: "2 luces no eran estrellas", isCorrect: false),
            }),

            new(question: "2. Al caminar por el puente del humilladero, observas que hay 13 arcos y cada uno tiene un farol. Ese d�a solo hab�a 7 faroles encendidos, <b>�Cu�ntos de los faroles estaban apagados en los 13 arcos?</b>", answers: new()
            {
                new Answer(answer: "5 faroles", isCorrect: false),
                new Answer(answer: "13 faroles", isCorrect: false),
                new Answer(answer: "6 faroles", isCorrect: true),
                new Answer(answer: "11 faroles", isCorrect: false),
            }),

            new(question: "3. Era un d�a soleado y el grupo de quinto de primaria decidi� subir la monta�a del morro de Tulc�n para disfrutar de la vista de la ciudad de Popay�n. El grupo observ� a 14 aves volando majestuosamente y se dieron cuenta que 8 eran c�ndores. Entonces, <b>�Cu�ntas de las aves no eran c�ndores?</b>", answers: new()
            {
                new Answer(answer: "10 c�ndores", isCorrect: false),
                new Answer(answer: "5 c�ndores", isCorrect: false),
                new Answer(answer: "6 c�ndores", isCorrect: true),
                new Answer(answer: "3 c�ndores", isCorrect: false),
            }),

            new(question: "4. Ya al explorar el volc�n Purac�, los ni�os encontraron en total 24 rocas blancas, sin embargo, de ellas 9 eran peque�as, <b>�Cuantas rocas entre las medianas y grandes quedaron al quitar las peque�as?</b>", answers: new()
            {
                new Answer(answer: "14 medianas y grandes", isCorrect: false),
                new Answer(answer: "16 medianas y grandes", isCorrect: false),
                new Answer(answer: "17 medianas y grandes", isCorrect: false),
                new Answer(answer: "15 medianas y grandes", isCorrect: true),
            }),

            new(question: "5. En la campa�a para la protecci�n del medio ambiente en el Cauca, los ni�os decidieron repartir unos volantes, en el primer d�a se imprimieron 500 y se lograron entregar 280, <b>�Cuantos volantes faltan por repartir?</b>", answers: new()
            {
                new Answer(answer: "220 volantes", isCorrect: true),
                new Answer(answer: "240 volantes", isCorrect: false),
                new Answer(answer: "235 volantes", isCorrect: false),
                new Answer(answer: "250 volantes", isCorrect: false),
            }),
        };

        return list;
    }

}
