import { apiFetch } from '@/services/api'
import type {
  SaveTrainingSessionRequest,
  SavedTrainingSessionResponse
} from '@/types/trainingSession'

export function saveTrainingSession(data: SaveTrainingSessionRequest) {
  return apiFetch<SavedTrainingSessionResponse>('/trainingsessions', {
    method: 'POST',
    body: JSON.stringify(data)
  })
}