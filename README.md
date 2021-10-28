# AudioEditorFT204

Проект “Аудиоредактор” для курса “Проектирование на языке C#”

Проблема, которую решает проект: 

Изменение тех или иных свойств аудиодорожки:

Например, пользователь захотел поменять кодек, для этого в приложении будет функция по конвертированию аудио.

Пользователь хочет обрезать аудио, программа ему в этом поможет

Пользователь хочет добавить новых эффектов в аудио, программа поможет ему с этим. И т.д.

Точки расширения:

1) Добавление форматов входящих аудиодорожек и форматов сохранения

2) Изменение содержимого аудиотракта (обрезка, 
Эффект эха, эквалайзер)

Слои приложения:

1) UI - Слой, отвечающий за отображение формы.

2) Application - Обработка сигналов от контролов.

3) Domain - Функции, отвечающие за изменение аудиодорожки (CutAudio, CycleAudio, InverseAudio, MergeAudio...)

4) Infrastructure - Функция изменения формата файла, функции открытия и сохранения аудиофайла.

Технологии:

1) Winforms

2) NAudio

Интерфейс:

1) byte[] CutAudio(Mp3FileReader audio), 

   byte[] CycleAudio(Mp3FileReader audio),

   byte[] InverseAudio(Mp3FileReader audio), 
   
   byte[] MergeAudio(Mp3FileReader audio),
   
   byte[] VolumeUpAudio(Mp3FileReader audio),
   
   byte[] SpeedUpAudio(Mp3FileReader audio)

2) void SaveAudio(byte[] audio)

   Mp3FileReader OpenAudio(string path)
   
3) Mp3FileReader ChangeAudioFormat(Mp3FileReader audio)

Авторы проекта:

Пермяков Артём, Бургарт Артём, Сергеев Егор
