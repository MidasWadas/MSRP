import fs from "fs";
import path from "path";
import postcss from "postcss";
import scss from "postcss-scss";

const folderPath = "./src"; // dostosuj do folderu z plikami SCSS

function fixMixedDecls(css) {
	return postcss([
		(root) => {
			root.walkRules((rule) => {
				// Szukamy przypadków gdzie po zagnieżdżonych regułach są deklaracje
				const declsAfterNested = [];
				let foundNestedRule = false;

				rule.each((node, index) => {
					if (node.type === "rule" || node.type === "atrule") {
						foundNestedRule = true;
					}
					if (foundNestedRule && node.type === "decl") {
						declsAfterNested.push(node);
					}
				});

				if (declsAfterNested.length > 0) {
					// Usuwamy te deklaracje z aktualnego miejsca
					declsAfterNested.forEach((d) => d.remove());
					// Wkładamy je *przed* zagnieżdżone reguły lub do & {}
					if (rule.nodes.length > 0) {
						// Wstawiamy deklaracje przed pierwszym zagnieżdżonym rulem
						const firstNestedIndex = rule.nodes.findIndex(
							(n) => n.type === "rule" || n.type === "atrule"
						);
						declsAfterNested.reverse().forEach((d) => {
							rule.insertBefore(rule.nodes[firstNestedIndex], d);
						});
					} else {
						// Jeśli nie ma nic, wrzucamy normalnie
						declsAfterNested.forEach((d) => rule.append(d));
					}
				}
			});
		},
	])
		.process(css, { syntax: scss })
		.then((result) => result.css);
}

async function processFile(filePath) {
	const css = fs.readFileSync(filePath, "utf8");
	const fixedCss = await fixMixedDecls(css);
	fs.writeFileSync(filePath, fixedCss, "utf8");
	console.log(`Fixed ${filePath}`);
}

function walkDir(dir) {
	fs.readdirSync(dir).forEach((file) => {
		const fullPath = path.join(dir, file);
		if (fs.statSync(fullPath).isDirectory()) {
			walkDir(fullPath);
		} else if (fullPath.endsWith(".scss")) {
			processFile(fullPath);
		}
	});
}

walkDir(folderPath);
