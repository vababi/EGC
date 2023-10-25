# Ababi-Vlad-3133B
1. Ce este un viewport?
	Viewport-ul este spatiul in care este desenat obiectul grafic.
2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
	Acest concept determina cate imagini per secunda trebuie sau pot fi reprezentate pe monitor.
3. Când este rulată metoda OnUpdateFrame()?
	Aceasta metoda se ruleaza de fiecare data cand este nevoie de afisat un nou cadru.
4. Ce este modul imediat de randare?
	Modul imediat de randare presupune trimiterea datelor despre fiecare vertex de la CPU direct spre GPU.
5. Care este ultima versiune de OpenGL care acceptă modul imediat?
	Incepand cu versiunea OpenGL 3.0 modul imediat nu mai este suportat,astfel ultima versiune suportata este OpenGL 2.1.
6. Când este rulată metoda OnRenderFrame()?
	Metoda data este rulata dupa chemarea lui SwapBuffers, deoarece se impune desenarea unei noi scene grafice, chiar daca nu au fost efectuate schimbari.
7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
	In timpul rularii acestei metode se adapteaza fereastra aplicatiei la dimensiunile ecranului pentru a nu aparea obiecte defecte.
8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
	metoda include 4 parametri:
		fieldOfView - campul de vedere intre 0 si 180 grade;
		aspectRatio - raportul dintre latimea si lungimea ferestrei, poate lua orice valoare reala;
		nearPlane - distanta de la camera pana la sectiunea de randat;
		farPlane - distanta pana la capatul volumului de randat.