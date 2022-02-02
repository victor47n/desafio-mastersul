import Document, { Html, Head, Main, NextScript } from 'next/document'

// Substituição da estrutura base Document
export default class MyDocument extends Document {
    render() {
        return (
            <Html>
                <Head>
                    <link rel="preconnect" href="https://fonts.googleapis.com" />
                    <link rel="preconnect" href="https://fonts.gstatic.com" />
                    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@500&family=Lexend:wght@500;600&display=swap" rel="stylesheet" />

                    <link rel="shortcut icon" href="/mastersul-favicon.png" type="image/png" />
                </Head>
                <body id="root">
                    {/* Todo o conteúdo da aplicação será renderizado dentro do <Main /> */}
                    <Main />
                    {/* Onde será inserido os arquivos js da aplicação */}
                    <NextScript />
                </body>
            </Html>
        )
    }
}