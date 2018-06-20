let icelandSquad = [
    "Hannes Þór Halldórsson"
    "Birkir Már Sævarsson"
    "Samúel Friðjónsson"
    "Albert Guðmundsson"
    "Sverrir Ingi Ingason"
    "Ragnar Sigurðsson"
    "Jóhann Berg Guðmundsson"
    "Birkir Bjarnason"
    "Björn Bergmann Sigurðarson"
    "Gylfi Sigurðsson"
    "Alfreð Finnbogason"
    "Frederik Schram"
    "Rúnar Alex Rúnarsson"
    "Kári Árnason"
    "Hólmar Örn Eyjólfsson"
    "Ólafur Ingi Skúlason"
    "Aron Gunnarsson"
    "Hörður Björgvin Magnússon"
    "Rúrik Gíslason"
    "Emil Hallfreðsson"
    "Arnór Ingvi Traustason"
    "Jón Daði Böðvarsson"
    "Ari Freyr Skúlason" ]

icelandSquad
|> List.countBy(fun name -> name.EndsWith "son")
|> printfn "%A"






