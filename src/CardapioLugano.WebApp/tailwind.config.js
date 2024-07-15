/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './../**/*.{razor,html,cshtml}'
    ],
  theme: {
      extend: {
          backgroundImage: {
              "home":"url('https://centraldofranqueado.com.br/franquias/_next/image/?url=https%3A%2F%2Fcdn-portal.centraldofranqueado.com.br%2Fcms%2F2021%2F04%2F06%2F606cb387787a2lugano_banner.jpg&w=3840&q=75')"
          }
      },
  },
  plugins: [],
}

