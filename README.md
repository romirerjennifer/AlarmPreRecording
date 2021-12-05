# AlarmPreRecording
Diplomarbeit der HTL Pinkafeld 2019 


Im Zuge dieser Diplomarbeit soll eine Möglichkeit geschaffen werden, bei Störmeldungen der Maschinensteuerung automatisch eine Videosequenz zu speichern, um die Fehlersituation später visuell darstellen zu können. Hierbei wird das, von den Kameras permanent aufgezeichnete, Videosignal zu einem Leitrechner übertragen. Die Kameras sollen flexible Vor- und Nachlaufzeiten haben, die die Fehlersituation vor und nach der auftretenden Störung aufnehmen sollen. Diese Zeiten sollen unabhängig voneinander einstellbar sein. Darüber hinaus soll die zu entwickelnde Software die Möglichkeit bieten, bei unterschiedlichen Fehlermeldungen der Maschine das Videosignal spezifischer Kameras zu speichern.

Die Gesamtzeit des Videos sollte höchstens eine Minute betragen und am Leitrechner in einen Ringpuffer gespeichert werden. Dieses Speichern erfolgt mit einer systematischen Bezeichnung, die das Datum, die Uhrzeit und die Kamera-ID enthält.
Die Verbindungen zwischen Leitrechner und Kamera, sowie die Verbindung zwischen Leitrechner und Steuerung sollen über Ethernet erfolgen.

![grafik](https://user-images.githubusercontent.com/94066791/144751808-7ffc5f0e-eba4-493f-be7a-116c424a481d.png)
