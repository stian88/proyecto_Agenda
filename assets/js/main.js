/*function guardarTarea(){
    var tareaInput = document.getElementById("input-tarea")
    var listado = document.getElementById("Listado-tareas")
    listado.innerHTML +=  `<li>${tareaInput.value}</li>`
    tareaInput.value = ""
}*/
var listadoTareas = [];

document.addEventListener("submit", function(event){
    
    event.preventDefault();
    var tarea = event.target[0].value

    if(tarea == ""){
       return alert("Completa el campo")
    } 

    listadoTareas.push(tarea)
   
    event.target[0].value = ""
    addTareaHtml()
})

function addTareaHtml(){
   var listadoHtml = document.getElementById("listado-tareas")
    const ultimaTarea = listadoTareas[listadoTareas.length - 1]
    listadoHtml.innerHTML  += `<li>${ultimaTarea}</li>`
   }
   
