import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
      'app': path.resolve(__dirname, 'src/app'),
      'components': path.resolve(__dirname, 'src/components'),
      'features': path.resolve(__dirname, 'src/features'),
      'hooks': path.resolve(__dirname, 'src/hooks'),
      'mocks': path.resolve(__dirname, 'src/mocks'),
      'services': path.resolve(__dirname, 'src/services'),
      'styles': path.resolve(__dirname, 'src/styles'),
      'types': path.resolve(__dirname, 'src/types'),
      'utils': path.resolve(__dirname, 'src/utils'),
    },
  },
})
