/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./**/*.{razor,html}"],
  theme: {
    extend: {
      fontFamily: {
        "press-start": ['"Press Start 2P"', "cursive"],
      },
      colors: {
        "bg-main": "#2C0200", // Main Background Color
        "bg-second": "#C52616", // Secondary Background Color
        "text-main": "#FEFAE0", // Main Text Color
        "text-second": "#FDE574", // Secondary Text Color
        "text-third": "#FFD200", // Tertiary Text Color E1CC6A
        "border-main": "#E1CC6A",
      },
    },
  },
  plugins: [],
};
