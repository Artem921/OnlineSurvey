\connect onlinesurveybd;
CREATE TABLE IF NOT EXISTS Surveys
(
    Id integer NOT NULL,
    Name text NOT NULL,
    Description text NOT NULL,
    CONSTRAINT pk_surveys PRIMARY KEY (Id)
);
INSERT INTO Surveys
VALUES(1, 'Фильмы', 'Анонимный опрос для статистики' ),
      (2, 'Оценка качества работы сотрудника', 'Анонимный опрос для улучшение качества');
CREATE TABLE IF NOT EXISTS Questions
(
    Id integer NOT NULL,
    Surveyid integer NOT NULL,
    Quaere text NOT NULL,
    CONSTRAINT pk_questions PRIMARY KEY (Id),
    CONSTRAINT fk_questions_surveys_surveyid FOREIGN KEY (Surveyid)
        REFERENCES Surveys (Id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);
INSERT INTO Questions
VALUES(1,1, 'Ваш любимый жанр'),
      (2,1, 'Выбирите двух актёров, которые вам симпатизируют из этого списка'),
      (3,1, 'В какое время суток вы смотрите фильм'),
      (4,2, 'Качество обслуживания'),
      (5,2, 'Решил ли он вашь вопрос'),
      (6,2, 'Оценка работы сотрудника');
CREATE TABLE IF NOT EXISTS Answers
(
    Id integer NOT NULL ,
    Questionid integer NOT NULL,
    Replys text[]  NOT NULL,
    CONSTRAINT pk_answers PRIMARY KEY (Id),
    CONSTRAINT fk_answers_questions_questionid FOREIGN KEY (Questionid)
        REFERENCES Questions (Id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);
INSERT INTO Answers 
VALUES(1,1,'{"Детектив","Фантастика","Ужасы","Драма","Комедия","Боевик"}'),
      (2,2,'{"Леонардо Ди Каприо","Бред Пит","Том Круз","Аль Пачино","Скот Аткинс"}'),
      (3,3,'{"Утром","Днём","Вечером"}'),
      (4,4,'{"Плохое","Хорошее","Отличное"}'),
      (5,5,'{"Да","Нет","Частично"}'),
      (6,6,'{"1","2","3","4","5"}');
CREATE TABLE IF NOT EXISTS Interviews
(
    Id text  NOT NULL,
    CONSTRAINT pk_interviews PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS Results
(
    Id uuid NOT NULL,
    Interviewid text NOT NULL,
    Results text NOT NULL,
    Questionid integer NOT NULL,
    CONSTRAINT pk_results PRIMARY KEY (Id),
    CONSTRAINT fk_results_interviews_interviewid FOREIGN KEY (Interviewid)
        REFERENCES Interviews (Id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
);
CREATE UNIQUE INDEX index_question_id ON Questions(Id)







