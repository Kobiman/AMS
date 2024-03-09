function printDiv() {
    var divContents = document.getElementById("PrintDiv").innerHTML;
    var a = window.open('', '', 'height=500, width=250');
    a.document.write('<html>');
    a.document.write('<body > <br>');
    a.document.write(divContents);
    a.document.write('</body></html>');
    a.document.close();
    a.print();
}