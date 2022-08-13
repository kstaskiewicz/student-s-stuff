const licz = document.querySelector("#licz");
const czysc = document.querySelector("#czysc");
const wynikDodawania = document.querySelector("#wynikDodawania");
const wynikOdejmowania = document.querySelector("#wynikOdejmowania");
const wynikMnozenia = document.querySelector("#wynikMnozenia");
const wynikDzielenia = document.querySelector("#wynikDzielenia");

licz.addEventListener("click", (e) => {
  e.preventDefault();
  const number1 = document.querySelector("#number1");
  const number2 = document.querySelector("#number2");

  if (parseInt(number2.value) == 0) {
    alert("Nie możesz dzielić przez zero");
    return;
  }
  let div = "";
  [...number2.value]
    .reverse()
    .forEach(
      (a, index) =>
        (div += mnozenie(
          a,
          parseInt(number1.value),
          index,
          [...number2.value].length - 1,
          parseInt(number2.value)
        ))
    );
  console.log(div);
  wynikDodawania.innerHTML = `<div style="line-height: 20px; font-family: monospace;"><span style="float: right">${
    number1.value
  }</span><br/> <span style="float:right">${
    number2.value
  }<span></div><br/><hr/> <div style="line-height: 20px; font-family: monospace;"><span style="float:right"> ${
    parseInt(number1.value) + parseInt(number2.value)
  }</span></div>`;
  wynikOdejmowania.innerHTML = `<div style="line-height: 20px; font-family: monospace;"><span style="float: right">${
    number1.value
  }</span><br/> <span style="float:right">${
    number2.value
  }<span></div><br/><hr/> <div style="line-height: 20px; font-family: monospace;"><span style="float:right"> ${
    parseInt(number1.value) - parseInt(number2.value)
  }</span></div>`;
  wynikMnozenia.innerHTML = `<div style="line-height: 20px; font-family: monospace;"><span style="float: right">${number1.value}</span><br/> <span style="float:right">${number2.value}<span></div><br/><hr/>${div}`;

  podziel_pisemnie();
});

czysc.addEventListener("click", () => {
  const number1 = document.querySelector("#number1");
  const number2 = document.querySelector("#number2");
  number1.value = 0;
  number2.value = 0;
  wynikDodawania.textContent = "";
  wynikOdejmowania.textContent = "";
  wynikMnozenia.textContent = "";
  wynikDzielenia.textContent = "";
});

function mnozenie(a, b, index, max, d) {
  let space = "";
  for (let i = 0; i < index; i++) {
    space += "&nbsp;";
  }
  if (index == max) {
    return `<div style="line-height: 20px; font-family: monospace;"><span style="float:right"> ${
      a * b
    }${space}</span></div><br/><hr/><div style="line-height: 20px; font-family: monospace;float:right">${
      b * d
    }</div>`;
  }
  return `<div style="line-height: 20px; font-family: monospace;"><span style="float:right"> ${
    a * b
  }${space}</span></div><br/><hr/>`;
}

function podziel_pisemnie() {
  var c = 1 * document.querySelector("#number1").value,
    f = 1 * document.querySelector("#number2").value,
    a = "";

  if (parseInt(c) && parseInt(f)) {
    var h = 0,
      d = 0,
      l = 0,
      g = 0,
      a =
        a +
        '<div style="margin-bottom: 20px; line-height: 20px; font-family: monospace;">';
    if (0 <= c && 0 < f) {
      if (c >= f)
        for (i = 0; i < c.toString().length; i++)
          if (
            ((d = 10 * d + parseInt(c.toString().substr(i, 1), 10)),
            f <= d || i == c.toString().length - 1)
          ) {
            w1 = Math.floor(d / f);
            if (0 == l) {
              l = 1;
              if (0 < i) for (j = 0; j < i; j++) a += " ";
              a += " ";
              wynik = Math.floor(c / f);
              a += wynik.toString();
              a += "<br ></c>";
              a += " ";
              a +=
                '<span style="text-decoration: overline;">' +
                c.toString() +
                "</span> : " +
                f.toString() +
                "<br />";
              g = 0;
            } else {
              e = w2.toString().length - d.toString().length + 1 + g;
              b = i + 2 - d.toString().length - e;
              if (0 < b) for (k = 1; k <= b; k++) a += " ";
              if (0 < e) for (k = 1; k <= e; k++) a += "=";
              a += d.toString() + "<br ></11yyy0ocvgocmu0rn>";
              g = 0;
            }
            w2 = w1 * f;
            b = i + 1 - w2.toString().length;
            if (0 < b) for (k = 1; k <= b; k++) a += " ";
            a +=
              '<span style="text-decoration: underline;">-' +
              w2.toString() +
              "</span>";
            d -= w2;
            a += "<br />";
            if (i + 1 == c.toString().length) {
              e = w2.toString().length - d.toString().length + g;
              b = i + 2 - d.toString().length - e;
              if (0 < b) for (k = 1; k <= b; k++) a += " ";
              if (0 < e) for (k = 1; k <= e; k++) a += "=";
              a += d.toString() + "<br ></b>";
              h = d;
            }
          } else g++;
      else {
        for (i = 0; i < c.toString().length; i++) a += " ";
        a += "0";
        a += "<br ></c>";
        a += " ";
        a +=
          '<span style="text-decoration: overline;">' +
          c.toString() +
          "</span> : " +
          f.toString() +
          "<br />";
        for (i = 0; i < c.toString().length - 1; i++) a += " ";
        a += '<span style="text-decoration: underline;">-0</span><br />';
        a += " " + c.toString() + "<br />";
        wynik = 0;
        h = c;
      }
      a += '<div style="font-family: serif;">';

      a += "</div>";
    } else
      (a +=
        '<span style="font-family: serif;">Zosta\u0142a wpisana z\u0142a warto\u015b\u0107 liczbowa.<br />'),
        0 == f && (a += "Nie wolno dzieli\u0107 przez 0!"),
        (a += "</span>");
    a += "</div>";
  } else
    a +=
      '<span style="font-family: serif;">Zosta\u0142a wpisana z\u0142a warto\u015b\u0107 liczbowa.<br />';
  document.querySelector("#podziel_pisemnie_wynik").innerHTML = a;
}
