const { globSync }    = require('glob');
const {exec} = require('child_process');

// 👇 Find every scoped CSS file
console.log('Processing files');

const files = globSync('Pages/**/*.cshtml.css');

files.forEach(function (file) {
  console.log(file);
  // 👇 Output the processed file as *.cshtml.css, which is a normal scoped CSS file
  const command = `npx postcss "${file}" -o "${file.replace('.cshtml.scss', '.cshtml.css')}"`;
  console.log(command)
  exec(command, (error, stdout, stderr) => {
    if (error) {
        console.error(`exec error: ${error}`);
        return;
    }
    console.log(`stdout: ${stdout}`);
    console.error(`stderr: ${stderr}`);
  });
});

console.log('Finished building scoped css');